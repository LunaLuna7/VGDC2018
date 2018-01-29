using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterTesting : MonoBehaviour {

	GameObject player;

	void Update () {
		Commands();
	}

	void Commands(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			ObjectSpawner.SpawnObjectWithParent(Spawnable.Bubble, player);
		}
	}
}
