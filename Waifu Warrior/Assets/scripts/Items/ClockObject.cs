using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockObject : MonoBehaviour {

    public GameObject Clock;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(Clock);
            Destroy(gameObject);
        }
    }
}
