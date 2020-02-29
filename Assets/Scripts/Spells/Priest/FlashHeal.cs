using System.Collections;
using UnityEngine;

public class FlashHeal : Spells
{
    public HolyWordSerenity holyWord;
    public RaidMember previousTarget;
    public Renew renew;

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;
            player.targetSpell.health = player.targetSpell.health + (player.spellPower * player.spellSellected.healPower);
            if (PlayerPrefs.GetInt("Talent40") == 4)
                talent4();
            if (PlayerPrefs.GetInt("Talent40") == 5)
                talent5();
            if (PlayerPrefs.GetInt("Talent40") == 6)
                talent6();         
            if (PlayerPrefs.GetInt("Talent100") == 13)
                holyWord.Decrease(2);
            holyWord.Decrease(6);
            StartCoroutine(CdVisualize(cooldown));
        }
    }

    void talent4()
    {
        if (previousTarget != null)
            previousTarget.health = previousTarget.health + 0.25f*(player.spellPower * player.spellSellected.healPower);
        previousTarget = player.targetSpell;
    }

    void talent5()
    {
        int randomX = Random.Range(0, 100);
        if (randomX > 75)
            renew.CastSpell();
    }

    void talent6()
    {
        if(costMana == 0 || castTime == 0)
        {
            costMana = 3;
            castTime = 1.5f;
        }
        int randomX = Random.Range(0, 100);
        if (randomX > 75)
        {
            costMana = 0;
            castTime = 0;
        }
    }
}
