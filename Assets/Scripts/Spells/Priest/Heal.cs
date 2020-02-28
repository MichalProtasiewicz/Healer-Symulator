using UnityEngine;

public class Heal : Spells
{
    public HolyWordSerenity holyWord;

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;
            player.targetSpell.health = player.targetSpell.health + (player.spellPower * player.spellSellected.healPower);
            StartCoroutine(CdVisualize(cooldown));
            if (PlayerPrefs.GetInt("Talent100") == 13)
                holyWord.Decrease(2);
            holyWord.Decrease(6);
        }
    }
}
