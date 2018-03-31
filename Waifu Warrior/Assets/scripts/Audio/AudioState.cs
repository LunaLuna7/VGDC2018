using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioState : MonoBehaviour {

    public int ID; //Know if its button ON or Button OFF

	// Use this for initialization
	void Start () {
        


        if (ID == 0) //Button ON
        {

            if (PlayerPrefs.GetInt("AudioSound") == 1)//Audio is playing
            {
                gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("AudioSound") == 0)//Audio muted
            {
                gameObject.SetActive(false);
            }
        }

        if (ID == 1) //Button OFF
        {

            if (PlayerPrefs.GetInt("AudioSound") == 1)//Audio is playing
            {
                gameObject.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("AudioSound") == 0)//Audio muted
            {
                gameObject.SetActive(true);
            }
        }
    }
	
	
	
}
