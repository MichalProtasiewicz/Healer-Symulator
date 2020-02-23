using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentController : MonoBehaviour
{
    public int talentId;
    public bool isActive;
    public Image borderImage;
    public Button button;

    void Start()
    {

    }

    void Update()
    {
        if (isActive)
            borderImage.color = new Color32(255,247,0,255);
        else
            borderImage.color = new Color32(192, 192, 192, 255);
    }
    
}
