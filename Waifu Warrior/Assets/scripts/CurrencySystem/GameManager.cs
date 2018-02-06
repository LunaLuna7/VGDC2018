using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {


    public static GameManager gameManager;
    [SerializeField] private int Money; //Players Money 

    public TMP_Text moneyText;


	void Start ()
    {
        gameManager = this;
        UpdateUI();
	}
	
	

    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateUI();
    }

    public void SubtractMoney(int amount)
    {
        Money -= amount;
        UpdateUI();
    }

    public bool CheckMoney(int amount)
    {
        if(amount <= Money)
        {
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        moneyText.text = "$ " + Money.ToString();
    }
}
