using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public RaidMember focus;
    public RaidMember targetSpell;

    public ManaSystem mana;

    public float spellPower;

    private float globalCooldown = 1.5f;
    public float timeNextSpell = 0.0f;
    public bool isCasting = false;

    public HealthBar castbar;
    public Text castText;


    public Spells spellSellected;

    private Coroutine spellRoutine;

    public Spells[] spellBook;

    private int playerExp;
    private int expNeedToLvl;
    private int playerLvl;

    void Start()
    {
        castText.text = "";
        castbar.fillAmount = 0;
        castbar.UpdateBar();

        if (PlayerPrefs.HasKey("PlayerSpellPower"))
            spellPower = PlayerPrefs.GetFloat("PlayerSpellPower");
    }

    public void CastSpell()
    {
        if (focus != null && focus.isAlive && Time.time > timeNextSpell)
        {
            if(Time.time > spellSellected.timeNextSpell)
            {
                if (mana.playerMana >= spellSellected.costMana)
                {
                    StopCasting();

                    timeNextSpell = Time.time + globalCooldown;

                    for(int i = 0; i<spellBook.Length; i++)
                    {
                        StartCoroutine(spellBook[i].CdVisualize(globalCooldown));
                    }

                    isCasting = true;
                    targetSpell = focus;

                    spellRoutine = StartCoroutine(UpdateCast());
                    

                }
                else
                {
                    // NO MANA
                }
            }
            else
            {
                // CD
            }

            
        }
        else
        {
            // DON'T HAVE TARGET or DEAD TARGET or GLOBAL CD  ----------------- TRZEBA POROZBIJAC TO I OBSLUZYC KONKRETNE PRZYPADKI
        }
    }

    public IEnumerator UpdateCast()
    {

        //DivineHym prowizorka
        if (spellSellected.cooldown > 150)
            spellSellected.CastSpell();

        if(spellSellected.castTime > 0)
        {
            float timePassed = Time.deltaTime;

            float rate = 1.0f / spellSellected.castTime;

            float progress = 0.0f;

            while (progress <= 1.0)
            {
                castbar.fillAmount = Mathf.Lerp(0, 1, progress);

                progress += rate * Time.deltaTime;

                timePassed += Time.deltaTime;

                castText.text = (spellSellected.castTime - timePassed).ToString("0.0") + "s";

                if (spellSellected.castTime - timePassed < 0)
                {
                    castText.text = ("0.0s");
                }

                castbar.UpdateBar();

                yield return null;
            }
        }

        //DivineHym prowizorka
        if (spellSellected.cooldown < 150)
            spellSellected.CastSpell();


        if (targetSpell.health > targetSpell.maxHealth)
            targetSpell.health = targetSpell.maxHealth;

        targetSpell.UpdateRaidBar();
        mana.playerMana = mana.playerMana - spellSellected.costMana;
        mana.UpdateManaBar();
        castText.text = "";
        castbar.fillAmount = 0;
        castbar.UpdateBar();

        isCasting = false;

        yield return null;
    }

    public void StopCasting()
    {
        if (spellRoutine != null)
        {
            StopCoroutine(spellRoutine);
            spellRoutine = null;
            castText.text = "";
            castbar.fillAmount = 0;
            castbar.UpdateBar();
            isCasting = false;
        }
    }

    public void CheckPlayerLevel(int expReward)
    {
        PlayerPrefs.SetInt("PlayerExp", PlayerPrefs.GetInt("PlayerExp") + expReward);

        playerLvl = 1;
        playerExp = PlayerPrefs.GetInt("PlayerExp");
        while (playerExp > 0)
        {
            expNeedToLvl = (playerLvl - 1 + 200 * 2 ^ ((playerLvl - 1) / 7)) / 6;
            if (playerExp >= expNeedToLvl)
            {
                playerExp = playerExp - expNeedToLvl;
                playerLvl++;
            }
            else
                break;
        }
        PlayerPrefs.SetInt("PlayerLevel", playerLvl);
    }

   
}
