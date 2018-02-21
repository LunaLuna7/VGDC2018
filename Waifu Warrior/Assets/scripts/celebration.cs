using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celebration : MonoBehaviour {

    public GameObject fireworks; //Particle Object

    void Start()
    {
        Instantiate(fireworks, transform.position, transform.rotation);
    }
}
