using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    public void ChangeToScene (int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
