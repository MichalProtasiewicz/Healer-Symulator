using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerOfMending : Spells
{

    public HolyWordSanctify holyWordSa;
    public HolyWordSerenity holyWordSe;

    public float stacks;

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;

            player.targetSpell.health = player.targetSpell.health + (player.spellPower * player.spellSellected.healPower);
            StartCoroutine(CdVisualize(cooldown));

            holyWordSa.Decrease(2);
            holyWordSe.Decrease(2);
        }
    }

}
