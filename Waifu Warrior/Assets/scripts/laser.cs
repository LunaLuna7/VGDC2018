using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Transform target;
    public float speed;
    Rigidbody2D rgbd;

    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        transform.right = target.position - transform.position;
        rgbd.velocity = transform.right * speed;
        StartCoroutine(DestroyObject());

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Gold"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
