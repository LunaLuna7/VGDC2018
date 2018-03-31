using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuardMove : MonoBehaviour {

    private int speed = 60;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        FindObjectOfType<AudioManager>().Play("Whistle");

    }

    void Update ()
    {
        
        Vector3 startPos = transform.position;
        transform.RotateAround(startPos, new Vector3(0, 0, -1), speed * Time.deltaTime);
        this.transform.position = player.transform.position;
        
	}
}
