using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Items{

    //Each item information

    public string ItemName;
    public int ItemID;

    public Sprite unboughtSprite;
    public Sprite boughtSprite;

    public int ItemPrice;

    public bool bought;
}
