using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hi");
        Destroy(gameObject);
    }

}

