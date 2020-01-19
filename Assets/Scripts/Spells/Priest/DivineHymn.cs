using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineHymn : Spells
{
    public RaidController raidController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            for (int i = 0; i < raidController.allRaid.GetLength(0); i++)
            {
                for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
                {
                    if (raidController.allRaid[i,j].isAlive)
                    {
                        raidController.allRaid[i,j].health = raidController.allRaid[i,j].health + (player.spellPower * player.spellSellected.healPower);
                    }
                }
            }
            
            timeNextSpell = Time.time + cooldown;
    
            StartCoroutine(CdVisualize(cooldown));

        }
    }

}
