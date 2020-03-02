using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    public GameObject window;

    public void OpenWindow()
    {
        window.SetActive(true);
    }
    public void CloseWindow()
    {
        window.SetActive(false);
    }
}
