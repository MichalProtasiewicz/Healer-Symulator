using UnityEngine;
using UnityEngine.UI;

public class BossLevelIndicator : MonoBehaviour
{
    public string bossName;
    public bool isActive;
    public string nameNeededToUnlock;
    public GameObject bossIndicator;


    void Start()
    {
        if(PlayerPrefs.GetFloat(nameNeededToUnlock) == 1 || nameNeededToUnlock == "")
        {
            isActive = true;
            bossIndicator.SetActive(true);
        }
        else
        {
            isActive = false;
            bossIndicator.SetActive(false);
        }


        Image indicatorImage = bossIndicator.GetComponent<Image>();

        if (PlayerPrefs.GetFloat(bossName) == 1)
            indicatorImage.color = new Color32(142, 142, 142, 255);
        else
            indicatorImage.color = new Color32(255, 0, 0, 255);


    }

    void Update()
    {
        
    }
}
