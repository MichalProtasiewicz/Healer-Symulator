using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InfoBarController : MonoBehaviour
{
    public TextMeshProUGUI playerLevelText;
    public TextMeshProUGUI playerGoldText;

    void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerLevel"))
            playerLevelText.text = "Level: " + PlayerPrefs.GetInt("PlayerLevel").ToString();
        else
            playerLevelText.text = "Level: 1";

        if (PlayerPrefs.HasKey("PlayerGold"))
            playerGoldText.text = PlayerPrefs.GetInt("PlayerGold").ToString();
        else
            playerGoldText.text = "0";
    }

}
