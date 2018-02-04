using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Bank
{

    public static int BankCoins; //The amount of gold overall.
    public static int CurrentGameCoins = 0; //The amount of gold in current gameplay.

    

    public static void IncrementCoin()
    {
        CurrentGameCoins++;
    }

    public static void IncrementBank()
    {
        BankCoins += CurrentGameCoins;
    }

    

}
