using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinUI : MonoBehaviour {

    [SerializeField] private TMP_Text Num_GameCoins; //Coins grab during this game play only.
    [SerializeField] private TMP_Text Total_Coins; //All the coins player owns.

	// Use this for initialization
	void Start () {
        PlayerPrefs.GetInt("PlayerGold");
        Num_GameCoins.text = 0.ToString();
        Total_Coins.text = PlayerPrefs.GetInt("PlayerGold").ToString();
	}
	
	// Update is called once per frame
	void Update () {

        PlayerPrefs.SetInt("PlayerGold", Bank.BankCoins);

        Num_GameCoins.text = Bank.CurrentGameCoins.ToString();
        
        //Total_Coins.text = PlayerPrefs.GetInt("PlayerGold").ToString();
    }   
}
