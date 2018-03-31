using System.Collections;
using UnityEngine.Advertisements;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour {

    public GameObject FailWindow;

	public void PlayAdd()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
    } 

    private void HandleAdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                GameManager.gameManager.AddMoney(20);
                break;

            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.Log("fail");
                AddFailed();
                break;

        }

    }
    private void AddFailed()
    {
        FailWindow.SetActive(true);
    }
}
