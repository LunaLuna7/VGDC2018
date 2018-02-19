using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    public TimeManager timeManager;
	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("Clock");
        
        StartCoroutine(DestroyObject());

    }

    IEnumerator DestroyObject()
    {
        timeManager.SlowMotion();
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManager>().Stop("Clock");
        Destroy(gameObject);
    }
}
