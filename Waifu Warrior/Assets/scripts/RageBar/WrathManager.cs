using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class WrathManager{

    public static float fillAmountWrath; //The fillamount


    public static void EmptyWrath()
    {
        fillAmountWrath = 0f;
    }

    public static bool FullWrath()
    {
        if(fillAmountWrath >= 1) // == max fillAmount
        {

            
            return true;
        }
        return false;
    }

}
