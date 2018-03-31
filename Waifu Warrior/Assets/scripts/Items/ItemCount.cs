using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour {

    public TMP_Text item_text;
    public Button item_button;

    private int amount;
	[SerializeField] Item item;

    void Start()
    {
		PersistentDataManager.LoadData ();
		amount = PersistentDataManager.masterData.itemList [(int)item]; 
        UpdateText();
        if(amount == 0)
        {
            item_button.interactable = false;
        }
    }

    public void decrement()
    {
        amount -= 1;
        PersistentDataManager.UseItem((int)item);
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
