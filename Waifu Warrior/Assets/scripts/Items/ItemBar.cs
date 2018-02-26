using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBar : MonoBehaviour {

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Clock;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject BodyGuards;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
        Instantiate(BodyGuards, player.transform.position, player.transform.rotation);
    }

    public void ShieldTrigger()
    {
        Instantiate(Shield, player.transform.position, player.transform.rotation);
    }
}
