using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;

    public TextMeshProUGUI textBossName;
    public Image iconDebuff1;
    public TextMeshProUGUI textDebuff1;
    public Image iconDebuff2;
    public TextMeshProUGUI textDebuff2;
    public TextMeshProUGUI textTips;
    public TextMeshProUGUI textTipsOffer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CloseWindow(GameObject specificBoss)
    {
        infoPanel.SetActive(false);
        specificBoss.SetActive(false);
    }

    public void OpenWindow(GameObject specificBoss)
    {
        infoPanel.SetActive(true);
        specificBoss.SetActive(true);
    }
}
