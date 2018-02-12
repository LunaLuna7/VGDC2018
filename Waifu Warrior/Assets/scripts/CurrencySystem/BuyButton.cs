using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour {

    public int itemID;

    public GameObject NotEnoughGoldWindow;

    public TMP_Text buttonText;

    public void BuyItem() //On click event
    {
        if (itemID == 0)
        {
            Debug.Log("Error: No weapon ID set"); //shouldnt see this.
            return;
        }

        for (int i = 0; i < ItemShop.itemShop.itemList.Count; i++)
        {
            if (ItemShop.itemShop.itemList[i].ItemID == itemID && !ItemShop.itemShop.itemList[i].bought && GameManager.gameManager.CheckMoney(ItemShop.itemShop.itemList[i].ItemPrice))
            {
                //We can buy item if hasnt been bought, have enough $$, and has same ID in the list.

                ItemShop.itemShop.itemList[i].bought = true;
                GameManager.gameManager.SubtractMoney(ItemShop.itemShop.itemList[i].ItemPrice);
                UpdateBuyButton();
            }

            //if they do not have enough gold.
            else if (ItemShop.itemShop.itemList[i].ItemID == itemID && !ItemShop.itemShop.itemList[i].bought && !GameManager.gameManager.CheckMoney(ItemShop.itemShop.itemList[i].ItemPrice))
            {
                NotEnoughGoldWindow.SetActive(true);
                Debug.Log("NO Enough money");
            }

            else if(ItemShop.itemShop.itemList[i].ItemID == itemID && ItemShop.itemShop.itemList[i].bought)
            {
                Debug.Log("Has been bought");
                
            }

        }
        ItemShop.itemShop.UpdateSprite(itemID);
    }

    public void UpdateBuyButton()
    {
        buttonText.text = "ON";
    }
}
