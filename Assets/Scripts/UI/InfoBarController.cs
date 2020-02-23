using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InfoBarController : MonoBehaviour
{
    public TextMeshProUGUI playerLevelText;

    void Awake()
    {
        if(PlayerPrefs.HasKey("PlayerLevel"))
        {
            playerLevelText.text = "Level:" + PlayerPrefs.GetInt("PlayerLevel").ToString();
        }
    }


}
