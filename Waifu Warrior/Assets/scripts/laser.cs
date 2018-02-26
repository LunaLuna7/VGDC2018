using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {


    public Transform Projectile;
    public Transform target;
    public float speed;
    public int health;
    Rigidbody2D rgbd;

    // Use this for initialization
    void Awake()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        Projectile.rotation = Quaternion.LookRotation(target.position - Projectile.position);
        rgbd.velocity = transform.forward * speed;
        
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move();

    }

    void Update()
    {

    }


    void Move()
    {
        
        //transform.position = Vector3.MoveTowards( transform.position, target.transform.position,speed * Time.deltaTime);
        //rgbd.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime));
    }
}
