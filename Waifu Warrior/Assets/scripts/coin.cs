using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour{

    void Start()
    {
        DestroyObjectDelayed();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 5);
    }
}

