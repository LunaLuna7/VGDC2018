using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour {

    public TMP_Text item_text;
    public Button item_button;

    private int amount;
	[SerializeField] int index;

    void Start()
    {
		PersistentDataManager.LoadData ();
		amount = PersistentDataManager.masterData.itemList [index]; //I buy item but not reflected on game item bar
        UpdateText();
        if(amount == 0)
        {
            item_button.interactable = false;
        }
    }

    public void decrement()
    {
        amount -= 1;
        //PersistentDataManager.UseItem(1); //<----how do i get which item to decrease?
        UpdateText();
        if (amount == 0) //amount <= -4
        {
            item_button.interactable = false;
        }
    }

    public void SetValue(int value)
    {
        amount = value;
        if(amount <= 0)
        {
            item_button.interactable = false;
        }
        if(amount < 0)
        {
            amount = 0;
        }
        UpdateText();
    }

    void UpdateText()
    {
        item_text.text = amount.ToString();
    }
}
