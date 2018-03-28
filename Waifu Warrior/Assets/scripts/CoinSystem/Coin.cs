using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	
	void Start ()
    {
        DestroyOnTime();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //This may have to change too $$
        {
            OnTouch();
        }
    }


    void OnTouch()
    {
        FindObjectOfType<AudioManager>().Play("coin");
        Bank.IncrementCoin();
        GameManager.gameManager.AddMoney(1);
        Destroy(gameObject);
    }

    void DestroyOnTime()
    {
        Destroy(gameObject, 5);
    }
}
