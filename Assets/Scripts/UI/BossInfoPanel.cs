using UnityEngine;


public class BossInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;

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
