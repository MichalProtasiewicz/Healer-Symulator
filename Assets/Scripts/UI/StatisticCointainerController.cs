﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticCointainerController : MonoBehaviour
{
    public TextMeshProUGUI playerIntellectText;
    public TextMeshProUGUI playerSpellPowerText;
    public TextMeshProUGUI playerSpiritText;
    public TextMeshProUGUI playerManaRegenText;

    void Awake()
    {
        ///INT

        /// SpellPower
        if (PlayerPrefs.HasKey("PlayerSpellower"))
            playerSpellPowerText.text = "Spell Power: " + PlayerPrefs.GetFloat("PlayerSpellower").ToString();
        else
        {
            PlayerPrefs.SetFloat("PlayerSpellower", 10);
            playerSpellPowerText.text = "Spell Power: " + PlayerPrefs.GetFloat("PlayerSpellower").ToString();
        }

        /// Spirit

        ///ManaRegen
        if (PlayerPrefs.HasKey("PlayerManaRegenerate"))
            playerManaRegenText.text = "Mana Regen: " + PlayerPrefs.GetFloat("PlayerManaRegenerate").ToString();
        else
        {
            PlayerPrefs.SetFloat("PlayerManaRegenerate", 0.5f);
            playerManaRegenText.text = "Mana Regen: " + PlayerPrefs.GetFloat("PlayerManaRegenerate").ToString();
        }
    }


}