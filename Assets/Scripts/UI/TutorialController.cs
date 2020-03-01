﻿using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex = 0;

    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
                popUps[i].SetActive(true);
            else
                popUps[i].SetActive(false);
        }
    }
    public void CloseWindow()
    {
        popUpIndex ++;
    }
}
