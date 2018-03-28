using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathRing : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Wave");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyObject());
    }

    void Update()
    {
        this.transform.position = player.transform.position;
        Quaternion target = Quaternion.Euler(0, 0, 180f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime );
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
