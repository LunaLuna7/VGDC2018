using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour 
{
	public void TestFunction(string sceneToLoad){
		SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
	}
}
