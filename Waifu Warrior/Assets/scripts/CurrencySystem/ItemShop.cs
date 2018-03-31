using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour {

    public static ItemShop itemShop; //create an instance of ItemShop that is static.

    public List<Items> itemList = new List<Items>(); //Creates a Dynamic list that you can resize and add items of type Items script

    private List<GameObject> ItemHolderList = new List<GameObject>(); //the list if item images in the item list.

    private List<GameObject> buyButtonList = new List<GameObject>(); //The list  of buy buttons in the item list

    public GameObject ItemHolderPrefab; //Where the Item holder object goes
    public Transform grid;

    void Start()
    {
        itemShop = this; //Makes self/this be the static instance at start of game. 
        FillList();
    }

    void FillList() //Instantiates an itemholder object into the grid in the UI
    {
		//int[] loadData = PersistentDataManager.GetItemAmounts ();
		PersistentDataManager.LoadData();
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject holder = Instantiate(ItemHolderPrefab, grid, false);
            ItemHolder holderScript = holder.GetComponent<ItemHolder>(); //Gain acces to the stuff in ItemHolder(the individual info of each item).

            holderScript.itemName.text = itemList[i].ItemName;
            holderScript.itemPrice.text = itemList[i].ItemPrice.ToString();
            holderScript.itemID = itemList[i].ItemID;
			holderScript.amount.text = PersistentDataManager.GetItemAmount(i).ToString ();

            //the buy button
            holderScript.buyButton.GetComponent<BuyButton>().itemID = itemList[i].ItemID;

            //The list to update the sprite
            ItemHolderList.Add(holder);
            buyButtonList.Add(holderScript.buyButton); //keeps track of whihc button.

			itemList [i].bought = PersistentDataManager.GetItemAmount(i)>0?true:false;
			if (itemList[i].bought == true)
            {                                                               //v----the sub directory.
                holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + itemList[i].SpriteName); //Goes to the Resources directory to grab the right sprites.
            }
            else
            {
                holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + "Lock" + itemList[i].SpriteName); //I manually change the sprite we getting by adding "Lock" to name
                                                                                                                        //Since all my locked versions are same name but Locked at start of string
                                                                                                                        //ex: Clock and LockClock
            }
        }
    }

	public void UpdateItemAmount(int currentItemID){
		for (int i = 0; i < ItemHolderList.Count; i++)
		{
			ItemHolder holderScript = ItemHolderList[i].GetComponent<ItemHolder>();
			if (holderScript.itemID == currentItemID)
			{
				for (int j = 0; j < itemList.Count; j++)
				{
					if (itemList[j].ItemID == currentItemID)
					{

						holderScript.amount.text = PersistentDataManager.GetItemAmount(currentItemID - 1).ToString();
                        if (holderScript.amount.text == "0")
                        {
                            holderScript.bar1.SetActive(false);
                            holderScript.bar2.SetActive(false);
                            holderScript.bar3.SetActive(false);
                            holderScript.bar4.SetActive(false);
                            holderScript.bar5.SetActive(false);
                        }
                        if (holderScript.amount.text == "1")
                        {
                            holderScript.bar1.SetActive(true);
                        }
                        if (holderScript.amount.text == "2")
                        {
                            holderScript.bar1.SetActive(false);
                            holderScript.bar2.SetActive(true);
                        }
                        if (holderScript.amount.text == "3")
                        {
                            holderScript.bar2.SetActive(false);
                            holderScript.bar3.SetActive(true);
                        }
                        if (holderScript.amount.text == "4")
                        {
                            
                            holderScript.bar3.SetActive(false);
                            holderScript.bar4.SetActive(true);
                        }
                        if (holderScript.amount.text == "5")
                        {
                            holderScript.bar4.SetActive(false);
                            holderScript.bar5.SetActive(true);
                        }
                    }

				}
			}

		}
	}

    public void UpdateSprite(int currentItemID)
    {
        for (int i = 0; i < ItemHolderList.Count; i++)
        {
            ItemHolder holderScript = ItemHolderList[i].GetComponent<ItemHolder>();
            if (holderScript.itemID == currentItemID)
            {
                for (int j = 0; j < itemList.Count; j++)
                {
                    if (itemList[j].ItemID == currentItemID)
                    {
                        if (itemList[j].bought == true)
                        {                                                               
                            holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + itemList[i].SpriteName);
                            //holderScript.itemPrice.text = ""; //After bought change string to empty.
                        }
                        else
                        {
                            holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + "Lock" + itemList[i].SpriteName);
                                                                                                                                                                                                                                                                    
                        }
                    }
                }
            }

        }
    }
}



