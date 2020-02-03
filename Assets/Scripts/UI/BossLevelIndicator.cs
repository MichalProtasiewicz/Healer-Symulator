using UnityEngine;

public class BossLevelIndicator : MonoBehaviour
{
    public bool isActive;
    public string bossName;
    public GameObject bossIndicator;

    void Start()
    {
        if(PlayerPrefs.GetFloat(bossName) == 1)
        {
            isActive = true;
            bossIndicator.SetActive(true);
        }
        else
        {
            isActive = false;
            bossIndicator.SetActive(false);
        } 
    }

    void Update()
    {
        
    }
}
