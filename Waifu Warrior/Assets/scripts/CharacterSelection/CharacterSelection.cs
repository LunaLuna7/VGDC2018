using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelection : MonoBehaviour {

    private GameObject[] characterList;

    private int index;

    // Use this for initialization
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)

            characterList[i] = transform.GetChild(i).gameObject;


        foreach (GameObject go in characterList)
            go.SetActive(false);


        if (characterList[index])
            characterList[index].SetActive(true);
    }

    public void Toggleleft()
    {
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = characterList.Length - 1;
        characterList[index].SetActive(true);
    }

    public void Toggleright()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
            index = 0;
        characterList[index].SetActive(true);
    }
    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
    }
}
