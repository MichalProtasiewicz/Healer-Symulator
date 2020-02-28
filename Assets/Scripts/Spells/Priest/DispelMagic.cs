using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispelMagic : Spells
{
    // Start is called before the first frame update
    void Start()
    {
        
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

            if(player.targetSpell.debuffIsActive == true)
            {
                StopCoroutine(player.targetSpell.debuffCoroutine);
                player.targetSpell.debuffIsActive = false;
                player.targetSpell.debuffIndicator.SetActive(false);

                StartCoroutine(CdVisualize(cooldown));
            }
            if (PlayerPrefs.GetInt("Talent80") == 11)
                player.targetSpell.health = player.targetSpell.health + 0.1f*player.spellPower;
        }
    }

}
