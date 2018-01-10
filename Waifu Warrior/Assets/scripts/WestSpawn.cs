using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestSpawn : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());

	}

	// Update is called once per frame
	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while (true){
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}	
			yield return new WaitForSeconds(waveWait);
		}

	}

}
