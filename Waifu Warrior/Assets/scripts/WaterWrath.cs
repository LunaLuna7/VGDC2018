using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWrath : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("rain");
        FindObjectOfType<AudioManager>().Play("bubble");
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
        FindObjectOfType<AudioManager>().Stop("rain");
        FindObjectOfType<AudioManager>().Stop("bubble");
        Destroy(gameObject);
    }
}
