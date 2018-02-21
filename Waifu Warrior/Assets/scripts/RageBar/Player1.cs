using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    [SerializeField]
    private Stat rage;

    private void Awake()
    {
        rage.Initialize();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rage.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rage.CurrentVal += 10;
        }
    }
}
