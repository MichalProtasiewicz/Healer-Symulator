using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex = 0;

    public RaidController raidController;

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

    public void StartFight()
    {
        raidController.isStarted = true;
    }
}
