using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalentsInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;
    public Image image;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI infoText;

    public Sprite[] sprites;

    public TalentsSceneController talentsSceneController;

    public int actualOpenTalentId;

    public struct TalentInfo
    {
        public int talentId;
        public string talentName;
        public string talentInfo;

        public TalentInfo(int talentId, string talentName, string talentInfo)
        {
            this.talentId = talentId;
            this.talentName = talentName;
            this.talentInfo = talentInfo;
        }
    }

    List<TalentInfo> TalentsInfo = new List<TalentInfo>();

    void Awake()
    {
        TalentInfo talent1 = new TalentInfo(0, "Heal", "Si immediate danger.");
        TalentInfo talent2 = new TalentInfo(1, "Flash Heal", "Simple singns, where the target is in danger of dying.");
        TalentInfo talent3 = new TalentInfo(2, "Renew", "Heals the target over 15 secondd to heal tanks or constantly low damage.");
        TalentInfo talent4 = new TalentInfo(3, "Dispel Magic", "Allows you to remove our ally.");
        TalentInfo talent5 = new TalentInfo(4, "Prayer of Healing", "Heals the targetyour most reliable sources of AoE healing.");
        TalentInfo talent6 = new TalentInfo(5, "Prayer of Mending", "Places a buff on the targeted when they take damage and jumps to ane of your most efficient Talents.");
        TalentInfo talent7 = new TalentInfo(6, "Divine Hymn", "Channeled Talent that han be used to mitigate high raid damage.");
        TalentInfo talent8 = new TalentInfo(7, "Holy Word Serenity", "Instant cast, single-target heal withng Heal or Flash Heal.");
        TalentInfo talent9 = new TalentInfo(8, "Holy Word Sanctify", "Instant cast Talent that heals target group.  of Healing or Renew.");
        TalentInfo talent10 = new TalentInfo(9, "Holy Word Sanctify", "Instant cast Talent that hf Healing or Renew.");
        TalentInfo talent11 = new TalentInfo(10, "Holy Word Sanctify", "Instant cast Talting Prayer of Healing or Renew.");
        TalentInfo talent12 = new TalentInfo(11, "Holy Word Sanctify", "Instant cast Talent that heals sting Prayer of Healing or Renew.");
        TalentInfo talent13 = new TalentInfo(12, "Holy Word Sanctify", "Instant cast Talent that heals target group. It hasealing or Renew.");
        TalentInfo talent14 = new TalentInfo(13, "Holy Word Sanctify", "Instant cast Talent that heals target group. It has a 60-second cooldown, which can beng or Renew.");
        TalentInfo talent15 = new TalentInfo(14, "Holy Word Sanctify", "Instant cast Talent thatcond cooldown, which can be further reduced by casting Prayer of Healing or Renew.");

        TalentsInfo.Add(talent1);
        TalentsInfo.Add(talent2);
        TalentsInfo.Add(talent3);
        TalentsInfo.Add(talent4);
        TalentsInfo.Add(talent5);
        TalentsInfo.Add(talent6);
        TalentsInfo.Add(talent7);
        TalentsInfo.Add(talent8);
        TalentsInfo.Add(talent9);
        TalentsInfo.Add(talent10);
        TalentsInfo.Add(talent11);
        TalentsInfo.Add(talent12);
        TalentsInfo.Add(talent13);
        TalentsInfo.Add(talent14);
        TalentsInfo.Add(talent15);
    }

    public void OpenTalentInfo(int talentId)
    {
        foreach (TalentInfo talentInfo in TalentsInfo)
        {
            if (talentInfo.talentId == talentId)
            {
                actualOpenTalentId = talentId;
                infoPanel.SetActive(true);
                image.sprite = sprites[talentId];
                nameText.text = talentInfo.talentName;
                infoText.text = talentInfo.talentInfo;
            }
        }
    }

    public void CloseTalentInfo()
    {
        infoPanel.SetActive(false);
    }

    public void LearnTalent()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(talentsSceneController.talents[i, j].talentId == actualOpenTalentId)
                {
                    talentsSceneController.talents[i, 0].isActive = talentsSceneController.talents[i, 1].isActive = talentsSceneController.talents[i, 2].isActive = false;
                    talentsSceneController.talents[i, j].isActive = true;
                    CloseTalentInfo();
                    PlayerPrefs.SetInt("talent"+ talentsSceneController.talents[i, j].unlockAtlvl, actualOpenTalentId);
                }

            }
        }
    }
}

