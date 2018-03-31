using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public static class PersistentDataManager {
    static Waifu selectedWaifu = Waifu.Nana; //Default waifu is Nana
    static int money;
    static int[] itemAmounts = new int[Data.itemEndIndex - Data.itemStartIndex];
    static bool[] waifusOwned = new bool[Data.waifuEndIndex - Data.waifuStartIndex];

    /// <summary>
    /// Create an empty save file
    /// </summary>
    static void CreateFile() {
        if (!File.Exists(Application.persistentDataPath + "/PlayerData.txt")) {
            StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerData.txt");
            sr.WriteLine(GetData());
            sr.Close();
        }
    }

    /// <summary>
    /// Write data to save file
    /// </summary>
    public static void SaveData() {
        try {
            CreateFile();
            string writeData = GetData();
            StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/PlayerData.txt");
            sr.WriteLine(writeData);
            sr.Close();
        }
        catch (Exception e) {
            Debug.Log("Save data failed. " + e);
        }
    }

    /// <summary>
    /// Try to load data from save file
    /// </summary>
    public static void LoadData() {
        try {
            CreateFile();
            StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
            string rawData = reader.ReadLine();
            string[] splitData = rawData.Split(',');
            reader.Close();

            //Save data to variables.
            //Load money
            GameManager.gameManager.SetMoney(Convert.ToInt32(splitData[(int)Data.money]));
            money = Convert.ToInt32(splitData[(int)Data.money]);

            //Load items
            for (int i = 0; i < (int)Data.itemEndIndex - (int)Data.itemStartIndex; i++) {
                itemAmounts[i] = Int32.Parse(splitData[i + (int)Data.itemStartIndex]);
            }

            //Load waifus
            selectedWaifu = (Waifu)Int32.Parse(splitData[(int)Data.selectedWaifuIndex]);
            for (int i = 0; i < (int)Data.waifuEndIndex - (int)Data.waifuStartIndex; i++) {
                waifusOwned[i] = splitData[i + (int)Data.waifuStartIndex].CompareTo("1") == 0;
                Debug.Log(splitData[i + (int)Data.waifuStartIndex]);
            }

            Debug.Log("Master Data:\nMoney=" + money + "\nItems:" + itemAmounts[0] + "," + itemAmounts[1] + "," + itemAmounts[2] + "," + itemAmounts[3] + "\nSelectedWaifu: " + selectedWaifu.ToString() + "\nWaifus:" + waifusOwned[0] + "," + waifusOwned[1] + "," + waifusOwned[2] + "," + waifusOwned[3]);

        }
        catch (Exception e) {
            Debug.Log("Load failed. " + e);
        }
    }

    /// <summary>
    /// Get the string to write to save file
    /// </summary>
    /// <returns></returns>
    public static string GetData() {
        //See enum Data for item ordering

        string toReturn = "";

        //Save money
        toReturn += GameManager.gameManager.GetMoney().ToString();

        //Save items
        for (int i = 0; i < itemAmounts.Length; i++) {
            toReturn += "," + itemAmounts[i].ToString();
        }

        //Save waifus
        toReturn += ',' + ((int)selectedWaifu).ToString();
        for (int i = 0; i < waifusOwned.Length; i++) {
            toReturn += "," + (waifusOwned[i] ? '1' : '0');
        }
        Debug.Log(toReturn);
        return toReturn;
    }

    /// <summary>
    /// Purchase an item and save data
    /// </summary>
    /// <param name="index"></param>
    public static void PurchaseItem(int index) {
        itemAmounts[index]++;
        SaveData();
    }

    /// <summary>
    /// Decrement item count and save data
    /// </summary>
    /// <param name="index"></param>
    public static void UseItem(int index) {
        itemAmounts[index]--;
        SaveData();
    }

    /// <summary>
    /// Modify money amount and save data
    /// </summary>
    /// <param name="value"></param>
    public static void ChangeMoney(int value) {
        money += value;
        SaveData();
    }

    /// <summary>
    /// Mark a waifu as "owned" and save data
    /// </summary>
    /// <param name="w"></param>
    public static void BuyWaifu(Waifu w) {
        waifusOwned[(int)w] = true;
        SaveData();
    }

    public static bool IsWaifuOwned(Waifu w) {
        return waifusOwned[(int)w];
    }

    /// <summary>
    /// Get the number of items
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static int GetItemAmount(Item i) {
        return GetItemAmount((int)i);
    }
    public static int GetItemAmount(int n) {
        return itemAmounts[n];
    }

    /// <summary>
    /// Change the selected waifu and save data
    /// </summary>
    /// <param name="w"></param>
    public static void ChangeSelectedWaifu(Waifu w) {
        selectedWaifu = w;
        SaveData();
    }
}

/// <summary>
/// Holds relevant information for where to find specific pieces of data in the save file
/// </summary>
public enum Data {
    money = 0,
    itemStartIndex = 1,
    itemEndIndex = 5,
    selectedWaifuIndex = 5,
    waifuStartIndex = 6,
    waifuEndIndex = 10
}

/// <summary>
/// In-game item indices
/// </summary>
public enum Item {
    Whistle = 0,
    Clock = 1,
    Candy = 2,
    Gun = 3
}

/// <summary>
/// Waifu indices
/// </summary>
public enum Waifu {
    Nana = 0,
    Emiko = 1,
    Sakura = 2,
    Sora = 3
}