using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWordSerenity : Spells
{
    private bool decreased;
    private float decreaseTime;
    public RaidController raidController;


    // Start is called before the first frame update
    void Start()
    {
        decreased = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;

            player.targetSpell.health = player.targetSpell.health + (player.spellPower * player.spellSellected.healPower);
            StartCoroutine(CdVisualize(cooldown));
        }
    }

    public void Decrease(float time)
    {
        decreaseTime = time;
        timeNextSpell -= decreaseTime;
        decreased = true;
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

            if( decreased == true)
            {
                float decreaseRate = rate * decreaseTime;

                progress += decreaseRate;
                timePassed += decreaseTime;
                decreased = false;
            }

            yield return null;
        }
        spellImage.fillAmount = 1;
        spellImage.color = new Color32(255, 255, 255, 255);

        if (PlayerPrefs.GetInt("Talent100") == 14 )
            Talent14();

        yield return null;
    }

    void Talent14()
    {
        for (int i = 0; i < raidController.allRaid.GetLength(0); i++)
        {
            for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
            {
                if (raidController.allRaid[i, j].isAlive)
                {
                    raidController.allRaid[i, j].health += 1.0f;
                }
            }
        }
    }




}
