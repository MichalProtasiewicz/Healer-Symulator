using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoreMenu : MonoBehaviour
{
    public GameObject moreMenuPanel;
    public bool isOppened;
    public TextMeshProUGUI buttonText;
    public Image buttonImage;


    private void Start()
    {
        isOppened = false;
        moreMenuPanel.SetActive(false);
        buttonImage.color = new Color32(255,255,255,255);
        buttonText.color = new Color32(255, 255, 255, 255);
    }

    public void OpenCloseMenu()
    {
        if(isOppened)
        {
            isOppened = false;
            moreMenuPanel.SetActive(false);
            buttonImage.color = new Color32(255, 255, 255, 255);
            buttonText.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            isOppened = true;
            moreMenuPanel.SetActive(true);
            buttonImage.color = new Color32(255, 247, 0, 255);
            buttonText.color = new Color32(255, 247, 0, 255);
        }
    }
}
