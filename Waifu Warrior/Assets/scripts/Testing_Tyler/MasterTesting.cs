using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterTesting : MonoBehaviour {

	GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
		Commands();
	}

	void Commands(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			ObjectSpawner.instance.SpawnObjectWithParent(Spawnable.Bubble, player);
		}
	}
}
