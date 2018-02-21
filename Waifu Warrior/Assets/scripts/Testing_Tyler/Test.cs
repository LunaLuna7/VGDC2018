using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

	public Text testText;

	void Start(){
		PersistentDataManager.LoadData ();
		UpdateText ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			//Load
			Debug.Log("Loading data and updating text...");
			UpdateText();
			PersistentDataManager.LoadData();
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			//Save
			Debug.Log("Saving GameManager...");
			PersistentDataManager.SaveData();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//Increment Money
			GameManager.gameManager.AddMoney(1);
			Debug.Log("Increment success!");
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//Decrement Money
			GameManager.gameManager.AddMoney(-1);
			Debug.Log("Decrement success!");
		}
	}

	void UpdateText(){
		testText.text = "Money: " + GameManager.gameManager.GetMoney ();
	}
}
