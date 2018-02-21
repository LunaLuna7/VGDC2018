using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour {

	
	public void ButtonClick()
    {
        FindObjectOfType<AudioManager>().Play("BubbleUI");
    }
	
	
}
