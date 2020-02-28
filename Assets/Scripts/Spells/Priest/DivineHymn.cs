using System.Collections;
using UnityEngine;

public class DivineHymn : Spells
{
    public RaidController raidController;
    private Coroutine divineHymnCoroutine;

    void Update()
    {
        if(player.spellSellected != this && divineHymnCoroutine != null)
            StopCoroutine(divineHymnCoroutine);
    }

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            divineHymnCoroutine = StartCoroutine(DivineHymnCo());
            StartCoroutine(CdVisualize(cooldown));
        }
    }

    public IEnumerator DivineHymnCo()
    {
        int healCdTimer = 0;
        for (int x = 0; x < castTime; x++)
        {
            if (healCdTimer == 0)
            {
                healCdTimer = 2;
                for (int i = 0; i < raidController.allRaid.GetLength(0); i++)
                {
                    for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
                    {
                        if (raidController.allRaid[i, j].isAlive)
                            raidController.allRaid[i, j].health = raidController.allRaid[i, j].health + (player.spellPower * player.spellSellected.healPower);
                    }
                }
            }
            healCdTimer--;
            yield return new WaitForSeconds(1); 
        }
        timeNextSpell = Time.time + cooldown;
    }

}
