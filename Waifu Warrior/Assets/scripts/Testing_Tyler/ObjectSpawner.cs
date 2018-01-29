using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public static GameObject[] spawnableObjects;

	void Start(){
		spawnableObjects = ObjectList.instance.GetList ();
	}

	public static void SpawnObjectWithParent(Spawnable obj, GameObject parent){
		SpawnObjectWithParent (obj, parent, Vector2.zero);
	}
	public static void SpawnObjectWithParent(Spawnable obj, GameObject parent, Vector2 localPosition){
		Instantiate (spawnableObjects [(int)obj], (Vector3)localPosition, Quaternion.identity, parent.transform);
	}
}

public enum Spawnable{
	Bubble = 0,
}
