using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        FindObjectOfType<AudioManager>().Play("Fire");

        StartCoroutine(DestroyObject());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(10);
        FindObjectOfType<AudioManager>().Stop("Fire");
        Destroy(gameObject);
    }
}
