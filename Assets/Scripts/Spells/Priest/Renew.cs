using System.Collections;
using UnityEngine;

public class Renew : Spells
{
    public HolyWordSanctify holyWord;

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;

            if(player.targetSpell.renewCoroutine != null)
            {
                StopCoroutine(player.targetSpell.renewCoroutine);
                player.targetSpell.renewIndicator.SetActive(false);
            }
            
            player.targetSpell.renewCoroutine = StartCoroutine(HealOverTime());

            StartCoroutine(CdVisualize(cooldown));

            holyWord.Decrease(2);
        }
    }

    public IEnumerator HealOverTime()
    {
        RaidMember raidMember = player.targetSpell;
        int healCdTimer = 0;

        raidMember.renewIndicator.SetActive(true);

        for (int i = 0; i < durationEffect; i++)
        {
            if(healCdTimer == 0)
            {
                healCdTimer = 3;
                raidMember.health = raidMember.health + (player.spellPower * player.spellSellected.healPower);
            }
            healCdTimer--;
            yield return new WaitForSeconds(1);
        }

        raidMember.renewIndicator.SetActive(false);
    }
}