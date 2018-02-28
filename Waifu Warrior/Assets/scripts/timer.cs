using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour {


    public TMP_Text timerText;
    private float StartTime;

    public Text gamescore;
    public Text highscore;

	// Use this for initialization
	void Start () {
        StartTime = Time.time;
        
        highscore.text = PlayerPrefs.GetFloat("Highscore").ToString("f2");
        gamescore.text = PlayerPrefs.GetFloat("Gamescore").ToString("f2");
	}



    // Update is called once per frame
    void Update () {
        float t = Time.time;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        timerText.text = minutes + ':' + seconds;
 

        if (t > PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", t);
            highscore.text = timerText.text;
        }
        PlayerPrefs.SetFloat("Gamescore", t);
        gamescore.text = timerText.text;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.DeleteKey("Gamescore");

    }


}
