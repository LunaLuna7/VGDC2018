using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MultiPage : MonoBehaviour
{

    private GameObject[] ChildList;

    private int Page = 0;

    // Use this for initialization
    void Start()
    {
        

        ChildList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)

            ChildList[i] = transform.GetChild(i).gameObject;


        foreach (GameObject go in ChildList)
            go.SetActive(false);


        if (ChildList[Page])
            ChildList[Page].SetActive(true);
    }

    public void Toggleleft()
    {
        ChildList[Page].SetActive(false);

        Page--;
        if (Page < 0)
            Page = ChildList.Length - 1;
        ChildList[Page].SetActive(true);
    }

    public void Toggleright()
    {
        ChildList[Page].SetActive(false);

        Page++;
        if (Page == ChildList.Length)
            Page = 0;
        ChildList[Page].SetActive(true);
    }
    
}
