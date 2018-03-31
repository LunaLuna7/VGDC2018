using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    //[SerializeField]private string MenuName;

	void Start () {
        FindObjectOfType<MusicManager>().Stop("GameSong");
        
        Time.timeScale = 0.0f;	
	}

    void Update()
    {
        FindObjectOfType<AudioManager>().Stop("Siren");
        FindObjectOfType<AudioManager>().Stop("Fire");
        FindObjectOfType<AudioManager>().Stop("Clock");
        FindObjectOfType<AudioManager>().Stop("Whistle");
        Time.timeScale = 0.0f;
    }



}
