using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public static class PersistentDataManager {
	static void CreateFile(){
		if (!File.Exists(Application.persistentDataPath + "/PlayerData.txt"))
		{
			StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerData.txt");
			sr.WriteLine(GetData());
			sr.Close();
		}
	}

	public static void SaveData(){
		try{
			CreateFile ();
			string writeData = GetData();
			StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/PlayerData.txt");
			sr.WriteLine(writeData);
			sr.Close();
		}
		catch(Exception e){
			Debug.Log ("Save data failed. " + e);
		}
	}

	public static void LoadData(){
		try{
			CreateFile ();
			StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
			string rawData = reader.ReadLine();
			string[] splitData = rawData.Split(',');
			reader.Close();

			//Save data to variables.
			GameManager.gameManager.SetMoney(Convert.ToInt32(splitData[(int)Data.money]));
		}
		catch(Exception e){
			Debug.Log ("Load failed. " + e);
		}
	}

	public static void LoadItemData(){
		CreateFile ();
		StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
		string rawData = reader.ReadLine();
		string[] splitData = rawData.Split(',');
		reader.Close();

		for (int i = (int)Data.itemStartIndex; i < (int)Data.itemEndIndex; i++) {
			if (i < ItemShop.itemShop.itemList.Count) {
				ItemShop.itemShop.itemList [i - (int)Data.itemStartIndex].bought = splitData [i] == "0" ? false : true;
			}
		}
	}

	public static string GetItemData(){
		CreateFile ();
		StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
		string rawData = reader.ReadLine();
		string[] splitData = rawData.Split(',');
		reader.Close();

		string toReturn = "";
		for (int i = (int)Data.itemStartIndex; i < (int)Data.itemEndIndex; i++) {
			toReturn += ',' + splitData [i];
		}
		return toReturn;
	}

	public static int[] GetItemAmounts(){
		CreateFile ();
		StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
		string rawData = reader.ReadLine();
		string[] splitData = rawData.Split(',');
		reader.Close();
		int[] toReturn = new int[(int)Data.itemEndIndex - (int)Data.itemStartIndex];

		for (int i = (int)Data.itemStartIndex; i < (int)Data.itemEndIndex; i++) {
			toReturn[i - (int)Data.itemStartIndex] = Int32.Parse(splitData [i]);
		}
		return toReturn;
	}

	public static string GetData(){
		//See enum Data for item ordering

		string toReturn = "";

		//Save money
		toReturn += GameManager.gameManager.GetMoney ().ToString ();

		//Save items
		if (ItemShop.itemShop != null) {
			for (int i = 0; i < ItemShop.itemShop.itemList.Count; i++) {
				toReturn += ',' + (ItemShop.itemShop.itemList [i].bought ? "1" : "0");
			}
		} else {
			toReturn += GetItemData ();
		}
			
		return toReturn;
	}

	public class PersistentData{
		int money;
		public List<Items> itemList = new List<Items>();
	}
}

public enum Data{
	money = 0,
	itemStartIndex = 1,
	itemEndIndex= 7,
}
