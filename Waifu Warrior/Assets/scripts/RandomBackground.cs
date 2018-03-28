using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour {


    public GameObject[] BackgroundArray;

    void Start()
    {
        FindObjectOfType<MusicManager>().Play("GameSong");
        FindObjectOfType<MusicManager>().Stop("MenuSong");
        //FindObjectOfType<AudioManager>().Play("Bell");
        Instantiate(BackgroundArray[Random.Range(0, BackgroundArray.Length)]);
    }


}
