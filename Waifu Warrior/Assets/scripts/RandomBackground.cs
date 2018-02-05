using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour {


    public GameObject[] BackgroundArray;

    void Start()
    {
        Instantiate(BackgroundArray[Random.Range(0, BackgroundArray.Length)]);
    }


}
