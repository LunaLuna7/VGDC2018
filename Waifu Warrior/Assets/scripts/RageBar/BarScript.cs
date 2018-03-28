using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour {
    [SerializeField] private Button RageBar;
    [SerializeField]//to make fillamount public but can only be access by inspector
    private float fillAmount;
    [SerializeField]//temporary
    private Image content;
    
    private bool singleRun = true;

    public float MaxValue{get; set;}

    private Animator wrathFace;

    public int player;
    public GameObject WrathRing;
    public GameObject ElectricShock;
    public GameObject WaterWave;
    public GameObject LightWave;

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
	// Use this for initialization
	void Start () {

        player = PlayerPrefs.GetInt("CharacterSelected");
        wrathFace = gameObject.GetComponent<Animator>();
        WrathManager.EmptyWrath();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckRage();
        HandleBar();    
	}

    private void HandleBar()
    {
        if(WrathManager.fillAmountWrath != fillAmount)
        {
            fillAmount = WrathManager.fillAmountWrath;
        }
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

    public void CheckRage()
    {
        
        if (WrathManager.FullWrath() && singleRun == true)
        {
            singleRun = false;
            FindObjectOfType<AudioManager>().Play("ChargedWrath");
            activateButton();
            
        }
    }

    public void activateButton()
    {
        RageBar.interactable = true;
        wrathFace.SetBool("Wrath", true);
        

    }

    public void useWrath()
    {
        singleRun = true;

        if (player == 0)
        {
            Instantiate(WrathRing);
        }
        if (player == 1)
        {
            Instantiate(ElectricShock);
        }
        if (player == 2)
        {
            Instantiate(WaterWave);
        }
        if (player == 3)
        {
            Instantiate(LightWave);
        }


        WrathManager.EmptyWrath();
        RageBar.interactable = false;
        wrathFace.SetBool("Wrath", false);
    }

    
 }


