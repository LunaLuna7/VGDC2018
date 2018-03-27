using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour {


    public TMP_Text timerText;
    //private float StartTime;
    private float time;
    public Text gamescore;
    public Text highscore;

	// Use this for initialization
	void Start () {
        //StartTime = Time.time;
        time = 0;
        
        highscore.text = PlayerPrefs.GetFloat("Highscore").ToString("f2");
        gamescore.text = PlayerPrefs.GetFloat("Gamescore").ToString("f2");
	}



    // Update is called once per frame
    void Update () {
        //float t = Time.time;
        time += Time.deltaTime;
        string minutes = ((int) time / 60).ToString();
        string seconds = (time % 60).ToString("f0");
        timerText.text = minutes + ':' + seconds;
 

        if (time > PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", time);
            highscore.text = timerText.text;
        }
        PlayerPrefs.SetFloat("Gamescore", time);
        //gamescore.text = timerText.text;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.DeleteKey("Gamescore");

    }


}
