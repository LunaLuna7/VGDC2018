using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuard : MonoBehaviour {

    private int speed = 60;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 startPos = transform.position;
        transform.RotateAround(startPos, new Vector3(0, 0, 1), speed * Time.deltaTime);

        
    }
}
