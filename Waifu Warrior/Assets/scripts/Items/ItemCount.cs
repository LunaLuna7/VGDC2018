using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour {

    public TMP_Text item_text;
    public Button item_button;

    [SerializeField] private int amount;

    void Start()
    {

        UpdateText();
    }

    public void decrement()
    {
        if(amount == 1)
        {
            item_button.interactable = false;
        }
        amount = amount - 1;
        UpdateText();
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
