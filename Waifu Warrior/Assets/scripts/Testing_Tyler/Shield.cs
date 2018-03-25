using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    [SerializeField]
    float duration;
    GameObject player;
    SpriteRenderer sr;

    void Start() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        FindObjectOfType<AudioManager>().Play("BubbleUI");
        player.GetComponent<Player>().immune = true;
        StartCoroutine(Blink());
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
    IEnumerator Blink()
    {
        //i am lazy to make while loop
        yield return new WaitForSeconds(duration -2);
        sr.enabled = false;
        yield return new WaitForSeconds(.1f);
        sr.enabled = true;
        yield return new WaitForSeconds(.5f);
        sr.enabled = false;
        yield return new WaitForSeconds(.1f);
        sr.enabled = true;
        yield return new WaitForSeconds(.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(.1f);
        sr.enabled = true;
        yield return new WaitForSeconds(.1f);
        sr.enabled = false;
        yield return new WaitForSeconds(.1f);
        sr.enabled = true;
        yield return new WaitForSeconds(.1f);
        sr.enabled = false;
        yield return new WaitForSeconds(.1f);
        sr.enabled = true;
        yield return new WaitForSeconds(.1f);
        sr.enabled = false;
        yield return new WaitForSeconds(.1f);
        sr.enabled = true;
        yield return new WaitForSeconds(.05f);
        sr.enabled = false;
        yield return new WaitForSeconds(.05f);
        sr.enabled = true;
        yield return new WaitForSeconds(.05f);
        sr.enabled = false;
        yield return new WaitForSeconds(.05f);
        sr.enabled = true;

    }
}
