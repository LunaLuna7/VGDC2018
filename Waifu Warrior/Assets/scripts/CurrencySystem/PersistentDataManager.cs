using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public static class PersistentDataManager {
    public static int[] itemAmounts = new int[Data.itemEndIndex - Data.itemStartIndex];
    public static Waifu selectedWaifu = Waifu.Nana; //Default waifu is Nana
    public static bool[] waifusOwned = new bool[Data.waifuEndIndex - Data.waifuStartIndex];
    public static int money;

    static void CreateFile() {
        if (!File.Exists(Application.persistentDataPath + "/PlayerData.txt")) {
            StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerData.txt");
            sr.WriteLine(GetData());
            sr.Close();
        }
    }

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

    public static void LoadItemData() {
        CreateFile();
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
        string rawData = reader.ReadLine();
        string[] splitData = rawData.Split(',');
        reader.Close();

        for (int i = (int)Data.itemStartIndex; i < (int)Data.itemEndIndex; i++) {
            if (i < ItemShop.itemShop.itemList.Count) {
                ItemShop.itemShop.itemList[i - (int)Data.itemStartIndex].bought = splitData[i] == "0" ? false : true;
            }
        }
    }

    public static string GetItemData() {
        CreateFile();
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
        string rawData = reader.ReadLine();
        string[] splitData = rawData.Split(',');
        reader.Close();

        string toReturn = "";
        for (int i = (int)Data.itemStartIndex; i < (int)Data.itemEndIndex; i++) {
            toReturn += ',' + splitData[i];
        }
        return toReturn;
    }

    public static int[] GetItemAmounts() {
        CreateFile();
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
        string rawData = reader.ReadLine();
        string[] splitData = rawData.Split(',');
        reader.Close();
        int[] toReturn = new int[(int)Data.itemEndIndex - (int)Data.itemStartIndex];

        for (int i = (int)Data.itemStartIndex; i < (int)Data.itemEndIndex; i++) {
            toReturn[i - (int)Data.itemStartIndex] = Int32.Parse(splitData[i]);
        }
        return toReturn;
    }

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

    public static void PurchaseItem(int index) {
        itemAmounts[index]++;
        Debug.Log("Item purchased at index " + index + ". Current tally: " + itemAmounts[index]);
        SaveData();
    }

    public static void UseItem(int index) {
        itemAmounts[index]--;
        SaveData();
    }

    public static void ChangeMoney(int value) {
        money += value;
        SaveData();
    }
}

public enum Data {
    money = 0,
    itemStartIndex = 1,
    itemEndIndex = 5,
    selectedWaifuIndex = 5,
    waifuStartIndex = 6,
    waifuEndIndex = 10
}

public enum Item {
    Whistle = 0,
    Clock = 1,
    Candy = 2,
    Gun = 3
}

public enum Waifu {
    Nana = 0,
    Emiko = 1,
    Sakura = 2,
    Sora = 3
}