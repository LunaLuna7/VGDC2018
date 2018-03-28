using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWrath : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyObject());
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        //FindObjectOfType<AudioManager>().Stop("Fire");
        Destroy(gameObject);
    }
}
