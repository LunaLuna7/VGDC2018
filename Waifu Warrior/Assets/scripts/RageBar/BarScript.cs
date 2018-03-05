using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField] private GameObject Rage_2;
    [SerializeField]//to make fillamount public but can only be access by inspector
    private float fillAmount;
    [SerializeField]//temporary
    private Image content;

    public float MaxValue{get; set;}

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
	// Use this for initialization
	void Start () {
        //Value = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Value = 0;
        HandleBar();
	}
    private void HandleBar()
    {
        if(fillAmount!= content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
      
    }
    
    private float Map(float value, float inMin,float inMax,float outMin, float outMax)
        //the current value, lowest amount, maximum hp,outMin/outMax-> scale 0 to 1
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        // Ex with 80 hp (80-0)*(1-0)/(100-0)+0 Max 100 min 0
        //80 * 1 / 100=0.8
        //Ex with 78 with max 230
        //(78-0)* (1-0)/ (230-0) + 0
        // 78*1 / 230 = 0.339

    }
    public void addRage()
       {
        if (WrathManager.FullWrath())
        {
            BarTrigger();
        }
    }
    public void BarTrigger()
    {
        Instantiate(Rage_2);
        Rage_2.gameObject.SetActive(true);
        WrathManager.EmptyWrath();
        Rage_2.gameObject.SetActive(false);
    }
    /*void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }*/
 }


