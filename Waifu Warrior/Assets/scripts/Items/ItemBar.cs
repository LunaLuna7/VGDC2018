using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBar : MonoBehaviour {


    [SerializeField] private GameObject Clock;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject BodyGuards;

    public void ClockTrigger()
    {
        Instantiate(Clock);
    }

    public void CrosshairTrigger()
    {
        Instantiate(crosshair);
    }

    public void GuardsTrigger()
    {
        Instantiate(BodyGuards);
    }
}
