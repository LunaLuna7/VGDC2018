using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockObject : MonoBehaviour {

    public GameObject Clock;
    public GameObject Itemgone;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(Itemgone, transform.position, transform.rotation);
            Instantiate(Clock);
            Destroy(gameObject);
        }
    }
}
