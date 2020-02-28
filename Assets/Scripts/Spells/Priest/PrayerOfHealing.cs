using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerOfHealing : Spells
{

    public RaidController raidController;

    public HolyWordSanctify holyWord;

    void Start()
    {
        if (PlayerPrefs.GetInt("Talent80") == 10)
            costMana -= 0.1f * costMana;
    }


    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;

            for (int i = 0; i < raidController.allRaid.GetLength(0); i++)
            {
                for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
                {
                    if(raidController.allRaid[i,j] == player.targetSpell)
                    {
                        for(int k = 0; k < raidController.allRaid.GetLength(1); k++)
                        {
                            if (raidController.allRaid[i, k].isAlive)
                            {
                                raidController.allRaid[i, k].health = raidController.allRaid[i, k].health + (player.spellPower * player.spellSellected.healPower);
                            }
                        }
                    }      
                }
            }

            StartCoroutine(CdVisualize(cooldown));

            if (PlayerPrefs.GetInt("Talent100") == 13)
                holyWord.Decrease(2);
            holyWord.Decrease(6);

        }
    }

}
