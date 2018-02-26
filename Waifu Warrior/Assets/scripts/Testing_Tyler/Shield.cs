using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    [SerializeField]
    float duration;
    GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().immune = true;
    }

    void OnDestroy() {
        player.GetComponent<Player>().immune = false;
    }



    void Update() {

        this.transform.position = player.transform.position;

        duration -= Time.deltaTime;
        if (duration <= 0) {
            Destroy(gameObject);
        }
    }
}
