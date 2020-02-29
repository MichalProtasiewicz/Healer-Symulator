using UnityEngine;

public class Heal : Spells
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
            StartCoroutine(CdVisualize(cooldown));
            if (PlayerPrefs.GetInt("Talent40") == 4)
                talent4();
            if (PlayerPrefs.GetInt("Talent40") == 5)
                talent5();
            if (PlayerPrefs.GetInt("Talent100") == 13)
                holyWord.Decrease(2);
            holyWord.Decrease(6);
        }
    }

    void talent4()
    {
        if (previousTarget != null)
            previousTarget.health = previousTarget.health + 0.25f * (player.spellPower * 1.5f);
        previousTarget = player.targetSpell;
    }

    void talent5()
    {
        int randomX = Random.Range(0, 100);
        if (randomX > 75)
            renew.CastSpell();
    }
}
