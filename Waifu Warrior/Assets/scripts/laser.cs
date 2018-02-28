using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{


    public Transform Projectile;
    public Vector3 target;
    public float speed;
    Rigidbody2D rgbd;

    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        target.z = 0f;

        Vector3 objectPos = transform.position;
        target.x = target.x - objectPos.x;
        target.y = target.y - objectPos.y;

        float angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
    
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        rgbd.velocity = transform.right * speed;

    }
    void Update()
    {
        //rgbd.velocity = transform.forward * speed;
    }

}
