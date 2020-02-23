using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalentsSceneController : MonoBehaviour
{
    public TalentController[,] talents;

    public TextMeshProUGUI talents20lvl, talents40lvl, talents60lvl, talents80lvl, talents100lvl;

    public int playerLvl;

    void Awake()
    {
        playerLvl = PlayerPrefs.GetInt("PlayerLevel");

        talents20lvl.color = talents40lvl.color = talents60lvl.color = talents80lvl.color = talents100lvl.color = new Color32(192, 192, 192, 255);

        talents = new TalentController[5, 3];
        int tmp = 1;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                talents[i, j] = GameObject.Find("Talent" + tmp).GetComponent<TalentController>();
                talents[i, j].button.interactable=false;
                tmp++;
            }
        }

        if (playerLvl >= 20)
        {
            talents[0, 0].button.interactable = talents[0, 1].button.interactable = talents[0, 2].button.interactable = true;
            talents20lvl.color = new Color32(255, 247, 0, 255);
        }
        if (playerLvl >= 40)
        {
            talents[1, 0].button.interactable = talents[1, 1].button.interactable = talents[1, 2].button.interactable = true;
            talents40lvl.color = new Color32(255, 247, 0, 255);
        }
        if (playerLvl >= 60)
        {
            talents[2, 0].button.interactable = talents[2, 1].button.interactable = talents[2, 2].button.interactable = true;
            talents60lvl.color = new Color32(255, 247, 0, 255);
        }
        if (playerLvl >= 80)
        {
            talents[3, 0].button.interactable = talents[3, 1].button.interactable = talents[3, 2].button.interactable = true;
            talents80lvl.color = new Color32(255, 247, 0, 255);
        }
        if (playerLvl >= 100)
        {
            talents[4, 0].button.interactable = talents[4, 1].button.interactable = talents[4, 2].button.interactable = true;
            talents100lvl.color = new Color32(255, 247, 0, 255);
        }

    }
}
