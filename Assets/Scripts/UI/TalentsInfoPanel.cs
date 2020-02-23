﻿using System.Collections;
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
        TalentInfo talent1 = new TalentInfo(0, "Spirit Enchance", "Light bless you, your mana regenerate faster.");
        TalentInfo talent2 = new TalentInfo(1, "Inteligence Power", "Long time meditation give you more inteligence");
        TalentInfo talent3 = new TalentInfo(2, "Prayer of Fortidue", "Powerfull stamina buff for all raid members.");
        TalentInfo talent4 = new TalentInfo(3, "Previous focus", "Heal and Flash Heal, heal previeous target for small amout");
        TalentInfo talent5 = new TalentInfo(4, "Renew renew", "Heal and Flash Heal can refresh renew on target.");
        TalentInfo talent6 = new TalentInfo(5, "Bonus Flash", "Cast Flash Heal have chance to make your next Flash Heal instant");
        TalentInfo talent7 = new TalentInfo(6, "Ressurect", "After Angel you not die.");
        TalentInfo talent8 = new TalentInfo(7, "Angel Bless", "Your angel form takes more time.");
        TalentInfo talent9 = new TalentInfo(8, "Revive", "You can ressurect first die person in your raid.");
        TalentInfo talent10 = new TalentInfo(9, "Prayer of Mana", "Prayer of Healing cost less mana.");
        TalentInfo talent11 = new TalentInfo(10, "Dispel Healing", "Dispel Magic also heal target.");
        TalentInfo talent12 = new TalentInfo(11, "Bless Hymn", "Untill Divine Hymn, Prayer of Mending jump to others members, without lose stacks.");
        TalentInfo talent13 = new TalentInfo(12, "Speed Holy Word", "Holy Word Serenity and Sanctify decrease cooldown more efficiently.");
        TalentInfo talent14 = new TalentInfo(13, "Holy Word Power", "When Holy Word Serenity or Sanctify finish cooldown, you will heal all raid for small amout.");
        TalentInfo talent15 = new TalentInfo(14, "Prayer over Time", "Prayer of Mending have chance to leave Renew.");

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

