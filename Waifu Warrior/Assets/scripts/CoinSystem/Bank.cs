using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bank
{

    public static int BankCoins = 0; //The amount of gold overall.
    public static int CurrentGameCoins = 0; //The amount of gold in current gameplay.

    public static void IncrementCoin()
    {
        CurrentGameCoins++;
    }


}
