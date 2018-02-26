using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuardMove : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update ()
    {
        this.transform.position = player.transform.position;
        
	}
}
