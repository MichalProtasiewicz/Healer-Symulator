using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerOfMending : Spells
{

    public HolyWordSanctify holyWordSa;
    public HolyWordSerenity holyWordSe;

    public float stacks;

    public RaidMember raidMember;

    private Coroutine pomCoroutine;

    public RaidController raidController;

    public Renew renew;

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;

            if(pomCoroutine != null)
            {
                raidMember.pomIndicator.SetActive(false);
            }
            pomCoroutine = StartCoroutine(PoMStacksBehavior());

            StartCoroutine(CdVisualize(cooldown));

            if (PlayerPrefs.GetInt("Talent100") == 13)
            {
                holyWordSa.Decrease(1);
                holyWordSe.Decrease(1);
            }
            holyWordSa.Decrease(2);
            holyWordSe.Decrease(2);
        }
    }

    public IEnumerator PoMStacksBehavior()
    {
        stacks = 5;
        raidMember = player.targetSpell;
        float healthTMP = raidMember.health;

        raidMember.pomIndicator.SetActive(true);
        raidMember.pomStacksText.text = stacks.ToString();


        for (int i = 0; i < durationEffect; i++)
        {
            //player get dmg
            if (healthTMP > raidMember.health)
            {   
                raidMember.health = raidMember.health + (player.spellPower * player.spellSellected.healPower);
                stacks--;
                raidMember.pomIndicator.SetActive(false);

                if (PlayerPrefs.GetInt("Talent100") == 15)
                    Talent15();

                if (stacks == 0)
                {
                    break;
                }
                else
                {
                    //random live member
                    int randomX;
                    int randomY;
                    do
                    {
                        randomX = Random.Range(0, raidController.allRaid.GetLength(0) - 1 );
                        randomY = Random.Range(0, raidController.allRaid.GetLength(1) - 1);
                    } while (raidController.allRaid[randomX, randomY].isAlive != true);

                    raidMember = raidController.allRaid[randomX, randomY];
                    raidMember.pomIndicator.SetActive(true);
                    raidMember.pomStacksText.text = stacks.ToString();
                }
            }
            healthTMP = raidMember.health;

            yield return new WaitForSeconds(1);
        }

        raidMember.pomIndicator.SetActive(false);
    }

    void Talent15()
    {
        int randomX = Random.Range(0, 100);
        if (randomX > 75)
            renew.CastSpell();
    }

}
