using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentController : MonoBehaviour
{
    public int talentId;
    public bool isActive;
    public Image talentImage;
    public Button button;

    void Start()
    {

    }

    void Update()
    {
        if (isActive)
            talentImage.color = new Color32(255,255,255,255);
        else
            talentImage.color = new Color32(192, 192, 192, 255);
    }
    
}
