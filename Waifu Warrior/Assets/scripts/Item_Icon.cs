using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Icon : MonoBehaviour {

    private Gold_Counter GoldAmount;


    

    void Start()
    {
        GoldAmount = GameObject.FindGameObjectWithTag("Gold").GetComponent<Gold_Counter>();

        DestroyObjectDelayed();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GoldAmount.gold += 1;
            Destroy(gameObject);

        }
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 5);
    }
}
