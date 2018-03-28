using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        FindObjectOfType<MusicManager>().Play("MenuSong");
        Time.timeScale = 1f;
        
        FindObjectOfType<MusicManager>().Stop("GameSong");
        FindObjectOfType<AudioManager>().Stop("Tap");
        FindObjectOfType<AudioManager>().Stop("Siren");
        FindObjectOfType<AudioManager>().Stop("Fire");
        FindObjectOfType<AudioManager>().Stop("Clock");
        FindObjectOfType<AudioManager>().Stop("Whistle");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
