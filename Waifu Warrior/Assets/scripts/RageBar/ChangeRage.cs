using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRage : MonoBehaviour {

    [SerializeField] private GameObject Rage_2;
    public void BarTrigger()
    {
        Instantiate(Rage_2);
    }
}
