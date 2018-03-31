using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicState : MonoBehaviour {

    public int ID; //Know if its button ON or Button OFF

    // Use this for initialization
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("MusicSound"));



        if (ID == 0) //Button ON
        {

            if (PlayerPrefs.GetInt("MusicSound") == 1)//Music is playing
            {
                gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("MusicSound") == 0)//Music muted
            {
                gameObject.SetActive(false);
            }
        }

        if (ID == 1) //Button OFF
        {

            if (PlayerPrefs.GetInt("MusicSound") == 1)//Music is playing
            {
                gameObject.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("MusicSound") == 0)//Music muted
            {
                gameObject.SetActive(true);
            }
        }
    }
}
