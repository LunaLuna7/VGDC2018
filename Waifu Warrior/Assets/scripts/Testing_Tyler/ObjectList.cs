using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {

	GameObject[] spawnableList;
	public static ObjectList instance;

	void Awake(){
		instance = this;
	}

	public GameObject[] GetList(){
		return spawnableList;
	}

}
