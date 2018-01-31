using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinUI : MonoBehaviour {

    [SerializeField] private TMP_Text Num_GameCoins;

	// Use this for initialization
	void Start () {
        Num_GameCoins.text = 0.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Num_GameCoins.text = Bank.CurrentGameCoins.ToString();
	}   
}
