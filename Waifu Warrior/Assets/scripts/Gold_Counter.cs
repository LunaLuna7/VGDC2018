using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gold_Counter : MonoBehaviour {

    public int gold;
    public Text GoldText;


    // Use this for initialization
    void Start () {
        gold = 0;
 
    }
	
	// Update is called once per frame
	void Update () {
        GoldText.text = gold.ToString();
    }
}
