using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject hazard;   //Object to instantiate
    public int hazardCount;     //Total number of objects spawned
    public float spawnWait;     //Time between spawning
    public float startWait;     //Initial wait time before spawning any objects
    public float waveWait;      //Time between each wave

    public int EnemyID; //Identifies which enemy and uses info to set hazardcount grow.

    [SerializeField] Vector2 topLeftSpawnPoint;
    [SerializeField] Vector2 bottomRightSpawnPoint;
    [SerializeField] int zSpawnPoint;

    // Use this for initialization
    void Start() {
        StartCoroutine(Increment());
        StartCoroutine(SpawnWaves());
    }

    IEnumerator Increment()
    {
        while (true)
        {
            if (EnemyID == 0)
            {
                yield return new WaitForSeconds(30);
                hazardCount = hazardCount += 1;
                //spawnWait = spawnWait -= .01f;
            }
            else
            {
                yield return new WaitForSeconds(10);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Instantiate(hazard, GetSpawnLocation(), Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }


    Vector3 GetSpawnLocation() {
        Direction direction = (Direction)Random.Range(0, 3);   //Sets a random direction

        if (direction == Direction.North) {
            return new Vector3(Random.Range(topLeftSpawnPoint.x, bottomRightSpawnPoint.x), topLeftSpawnPoint.y, zSpawnPoint);
        }
        else if (direction == Direction.East) {
            return new Vector3(bottomRightSpawnPoint.x, Random.Range(bottomRightSpawnPoint.y, topLeftSpawnPoint.y), zSpawnPoint);
        }
        else if (direction == Direction.South) {
            return new Vector3(Random.Range(topLeftSpawnPoint.x, bottomRightSpawnPoint.x), bottomRightSpawnPoint.y, zSpawnPoint);
        }
        else if (direction == Direction.West) {
            return new Vector3(topLeftSpawnPoint.x, Random.Range(bottomRightSpawnPoint.y, topLeftSpawnPoint.y), zSpawnPoint);
        }

        //This return statement should not be reached.
        Debug.LogError("Function GetSpawnLocation() returned a bad value.");
        return Vector3.zero;
    }
}

//Direction
//Starting from North, each increment rotates clockwise to the next cardinal direction
public enum Direction {
    North = 0,
    East = 1,
    South = 2,
    West = 3
}
