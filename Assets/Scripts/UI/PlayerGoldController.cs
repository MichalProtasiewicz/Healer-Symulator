using UnityEngine;

public class PlayerGoldController : MonoBehaviour
{
    public static void AddGold(int value)
    {
        PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + value);
    }
    public static void SpendGold(int value)
    {
        PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") - value);
    }
}
