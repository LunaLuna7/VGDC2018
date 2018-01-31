using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public float speed;
	public float chaseRange;
    public int health;
    Rigidbody2D rgbd;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
        rgbd = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }

	void Update () {

        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		/*float distanceToTarget = Vector3.Distance (transform.position, target.position);
		if (distanceToTarget < chaseRange) {
			Vector3 targetDir = target.position - transform.position;
			float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

			transform.Translate (Vector3.up * Time.deltaTime * speed);
		}*/
	}

	void OnMouseDown(){

        health = health - 1;

        if(health <= 0) 
        {
            Destroy(gameObject);
        }
	}

    void Move() {
        rgbd.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime));
    }
}
