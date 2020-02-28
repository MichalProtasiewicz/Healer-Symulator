using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{
    public float maxPlayerMana, playerMana, regenMana;
    public HealthBar manabar;
    public Text manaText;

    void Start()
    {
        playerMana = maxPlayerMana;
        manabar = GameObject.Find("ManaBar").GetComponent<HealthBar>();
        UpdateManaBar();
        InvokeRepeating("RegenerateMana", 0.0f, 1.0f );
        if (PlayerPrefs.HasKey("PlayerManaRegenerate"))
            regenMana = PlayerPrefs.GetFloat("PlayerManaRegenerate");
    }

    void Update()
    {
        CheckCorrectMana();
        UpdateManaBar();
    }

    public void CheckCorrectMana()
    {
        if (playerMana < 0)
            playerMana = 0;
        if (playerMana > maxPlayerMana)
            playerMana = maxPlayerMana;
    }

    public void UpdateManaBar()
    {
        manaText.text = ((playerMana / maxPlayerMana * 100).ToString("0") + "%");
        manabar.UpdateBar(playerMana, maxPlayerMana);
    }

    public void RegenerateMana()
    {
        if (playerMana < maxPlayerMana )
            playerMana += regenMana;
    }

}
