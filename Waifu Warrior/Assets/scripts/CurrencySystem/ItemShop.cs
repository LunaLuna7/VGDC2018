using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour {

    public static ItemShop itemShop; //create an instance of ItemShop that is static.

    public List<Items> itemList = new List<Items>(); //Creates a Dynamic list that you can resize and add items of type Items script

    public GameObject ItemHolderPrefab; //Where the Item holder object goes
    public Transform grid;

    void Start()
    {
        itemShop = this; //Makes self/this be the static instance at start of game. 
        FillList();
    }

    void FillList() //Instantiates an itemholder object into the grid in the UI
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject holder = Instantiate(ItemHolderPrefab, grid, false);
            ItemHolder holderScript = holder.GetComponent<ItemHolder>(); //Gain acces to the stuff in ItemHolder(the individual info of each item).

            holderScript.itemName.text = itemList[i].ItemName;
            holderScript.itemPrice.text = "$ " + itemList[i].ItemPrice.ToString();
            holderScript.itemID = itemList[i].ItemID;

            holderScript.buyButton.GetComponent<BuyButton>().itemID = itemList[i].ItemID;

            if (itemList[i].bought == true)
            {
                holderScript.itemImage.sprite = itemList[i].boughtSprite;
            }
            else
            {
                holderScript.itemImage.sprite = itemList[i].unboughtSprite;

            }
        }
    }
}
