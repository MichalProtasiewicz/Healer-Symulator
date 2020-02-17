using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellBookInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public Image image;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI infoText;

    public Sprite[] sprites; 

    public struct SpellInfo
    {
        public int spellId;
        public string spellName;
        public string spellInfo;

        public SpellInfo(int spellId, string spellName, string spellInfo)
        {
            this.spellId = spellId;
            this.spellName = spellName;
            this.spellInfo = spellInfo;
        }
    }

    List<SpellInfo> SpellsInfo = new List<SpellInfo>();

    void Awake()
    {
        SpellInfo heal = new SpellInfo(0, "Heal", "Slow, efficient, single target direct heal.");
        SpellInfo flashHeal = new SpellInfo(1, "Flash Heal", "Fast, more expensive single target heal.");
        SpellInfo renew = new SpellInfo(2, "Renew", "Weak direct heal with a Heal over Time effect");
        SpellInfo dispelMagic = new SpellInfo(3, "Dispel Magic", "Allows you to remove negative debuffs from your ally.");
        SpellInfo prayerOfHealing = new SpellInfo(4, "Prayer of Healing", "Costly proximity heal that heals the target group.");
        SpellInfo prayerOfMending = new SpellInfo(5, "Prayer of Mending", "A charge based heal that is cast on a friendly target which heals them when they take damage and then bounces to another friendly target if charges are remaining.");
        SpellInfo divineHymn = new SpellInfo(6, "Divine Hymn", "Large channeled raid cooldown that heals all raiders over time.");
        SpellInfo holyWordSerenity = new SpellInfo(7, "Holy Word Serenity", "Strong, instant direct heal.");
        SpellInfo holyWordSanctify = new SpellInfo(8, "Holy Word Sanctify", "Strong, instant heal that heals the target group.");


        SpellsInfo.Add(heal);
        SpellsInfo.Add(flashHeal);
        SpellsInfo.Add(renew);
        SpellsInfo.Add(dispelMagic);
        SpellsInfo.Add(prayerOfHealing);
        SpellsInfo.Add(prayerOfMending);
        SpellsInfo.Add(divineHymn);
        SpellsInfo.Add(holyWordSerenity);
        SpellsInfo.Add(holyWordSanctify);
    }

    public void OpenSpellInfo(int spellId)
    {
        foreach(SpellInfo spellInfo in SpellsInfo)
        {
            if(spellInfo.spellId == spellId)
            {
                infoPanel.SetActive(true);
                image.sprite = sprites[spellId];
                nameText.text = spellInfo.spellName;
                infoText.text = spellInfo.spellInfo;
            }
        }
    }

    public void CloseSpellInfo()
    {
        infoPanel.SetActive(false);
    }


}

