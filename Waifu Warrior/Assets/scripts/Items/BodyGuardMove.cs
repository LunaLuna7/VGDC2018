using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuardMove : MonoBehaviour {

    Vector3 player;
    //[SerializeField] private GameObject player;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.SetActive(true);
    }

    void Update ()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = player;
        
	}
}
