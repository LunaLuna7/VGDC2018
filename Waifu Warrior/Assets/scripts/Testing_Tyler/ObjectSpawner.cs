using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public static ObjectSpawner instance;

    public GameObject[] spawnableObjects;

	void Awake(){
        instance = this;
	}

	public void SpawnObjectWithParent(Spawnable obj, GameObject parent){
		SpawnObjectWithParent (obj, parent, Vector2.zero);
	}
	public void SpawnObjectWithParent(Spawnable obj, GameObject parent, Vector2 localPosition){
		GameObject temp = Instantiate (spawnableObjects [(int)obj], Vector2.zero, Quaternion.identity, parent.transform);
        temp.transform.localPosition = localPosition;
	}
}

public enum Spawnable{
	Bubble = 0,
}
