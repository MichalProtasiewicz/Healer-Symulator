using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomPanelActiveButton : MonoBehaviour
{
    public Image image;
    public GameObject text;

    void Start()
    {
        TextMeshProUGUI textmeshPro = text.GetComponent<TextMeshProUGUI>();
        image.color = new Color32(255, 247, 0, 255);
        textmeshPro.color = new Color32(255, 247, 0, 255);
    }
}
