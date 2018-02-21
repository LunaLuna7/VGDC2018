using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldObject : MonoBehaviour {

    //public GameObject shield;
    public GameObject Itemgone;
    

	void Start () {
        Destroy(gameObject, 5);	
	}
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(Itemgone, transform.position, transform.rotation);
         
            Destroy(gameObject);
        }
    }
}
