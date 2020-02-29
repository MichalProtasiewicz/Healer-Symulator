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
            StartCoroutine(CdVisualize(cooldown));
            if (PlayerPrefs.GetInt("Talent100") == 13)
                holyWord.Decrease(2);
            holyWord.Decrease(6);
        }
    }

    public override IEnumerator CdVisualize(float time)
    {
        float progress = 0.0f;
        float rate = 1.0f / time;
        float timePassed = Time.deltaTime;
        spellImage.color = new Color32(188, 188, 188, 255);
        while (progress <= 1.0)
        {
            spellImage.fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            timePassed += Time.deltaTime;
            yield return null;
        }
        spellImage.fillAmount = 1;
        spellImage.color = new Color32(255, 255, 255, 255);
        yield return null;
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
