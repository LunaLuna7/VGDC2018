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
		CreateFile ();
		StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/PlayerData.txt");
		sr.WriteLine(GetData());
		sr.Close();
	}

	public static void LoadData(){
		CreateFile ();
		StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
		string rawData = reader.ReadLine();
		string[] splitData = rawData.Split(',');
		reader.Close();

		//Save data to variables.
		GameManager.gameManager.SetMoney(Convert.ToInt32(splitData[(int)Data.money]));
		Debug.Log ("Money loaded: " + Convert.ToInt32(splitData[(int)Data.money]));
	}

	public static string GetData(){
		//int money
		//int hasGun <-- just got testing

		string toReturn = "";

		toReturn += GameManager.gameManager.GetMoney ().ToString () + ',';
		toReturn += "0";

		Debug.Log ("GetData(): " + toReturn);

		return toReturn;
	}
}

public enum Data{
	money = 0,
	hasGun = 1,
}
