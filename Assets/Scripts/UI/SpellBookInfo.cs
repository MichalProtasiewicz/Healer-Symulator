using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellBookInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public Image image;
    public TextMeshProUGUI nameText, infoText;
    public Sprite[] sprites; 
    public struct SpellInfo
    {
        public int spellId;
        public string spellName, spellInfo;

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
        SpellInfo heal = new SpellInfo(0, "Heal", "Simple single target heal with a long cast time. It is generally used to heal targets when they are not taking heavy damage and when they are not in immediate danger.");
        SpellInfo flashHeal = new SpellInfo(1, "Flash Heal", "Simple single target heal with a short cast time. It is useful in more pressing situations, where the target is in danger of dying.");
        SpellInfo renew = new SpellInfo(2, "Renew", "Heals the target over 15 seconds. It is generally used to heal tanks or constantly low damage.");
        SpellInfo dispelMagic = new SpellInfo(3, "Dispel Magic", "Allows you to remove harmful magic effects from your ally.");
        SpellInfo prayerOfHealing = new SpellInfo(4, "Prayer of Healing", "Heals the target group. It has a cast time, and it is one of your most reliable sources of AoE healing.");
        SpellInfo prayerOfMending = new SpellInfo(5, "Prayer of Mending", "Places a buff on the targeted ally, which heals them when they take damage and jumps to another ally (up to 5 times). This is one of your most efficient spells.");
        SpellInfo divineHymn = new SpellInfo(6, "Divine Hymn", "Channeled spell that heals all raid members. It is a powerful raid cooldown that can be used to mitigate high raid damage.");
        SpellInfo holyWordSerenity = new SpellInfo(7, "Holy Word Serenity", "Instant cast, single-target heal with a 60-second cooldown that can be further reduced by casting Heal or Flash Heal.");
        SpellInfo holyWordSanctify = new SpellInfo(8, "Holy Word Sanctify", "Instant cast spell that heals target group. It has a 60-second cooldown, which can be further reduced by casting Prayer of Healing or Renew.");

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

