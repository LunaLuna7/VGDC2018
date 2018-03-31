using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemHolder : MonoBehaviour {
    //Connects the Items type objects to the right UI elements.

    public TMP_Text itemName;
    public int itemID;
    public TMP_Text itemPrice;
    public Image itemImage;
    public GameObject buyButton;
	public TMP_Text amount;
	
}
