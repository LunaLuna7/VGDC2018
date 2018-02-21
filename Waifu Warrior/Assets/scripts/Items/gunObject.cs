using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunObject : MonoBehaviour {

    
    [SerializeField]private GameObject Itemgone;
    [SerializeField] private GameObject crosshair; 

    void Start()
    {
        
        Destroy(gameObject, 5);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Instantiate(Itemgone, transform.position, transform.rotation);
            Instantiate(crosshair, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
