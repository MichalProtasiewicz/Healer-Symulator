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
    //public Skills spellSellected;

    private float globalCooldown = 1.5f;
    public float timeNextSpell = 0.0f;
    private bool isCasting = false;

    public HealthBar castbar;
    public Text castText;


    public Spells spellSellected;

    private Coroutine spellRoutine;

    public Spells[] spellBook;

    

    // Start is called before the first frame update
    void Start()
    {
        castText.text = "";
        castbar.fillAmount = 0;
        castbar.UpdateBar();
    }

    // Update is called once per frame
    void Update()
    {

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
                    isCasting = false;

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
        
        spellSellected.CastSpell();

        if (targetSpell.health > targetSpell.maxHealth)
            targetSpell.health = targetSpell.maxHealth;

        targetSpell.UpdateRaidBar();
        mana.playerMana = mana.playerMana - spellSellected.costMana;
        mana.UpdateManaBar();
        castText.text = "";
        castbar.fillAmount = 0;
        castbar.UpdateBar();

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
        }
    }

   
}
