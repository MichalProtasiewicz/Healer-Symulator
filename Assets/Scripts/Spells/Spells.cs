using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    public float costMana;
    public float castTime;
    public float cooldown;
    public float healPower;
    public float durationEffect;

    public float timeNextSpell = 0.0f;

    public Player player;

    public Image spellImage;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void CastSpell()
    {
        if (player.targetSpell != null && player.targetSpell.isAlive && Time.time > timeNextSpell)
        {
            timeNextSpell = Time.time + cooldown;

            player.targetSpell.health = player.targetSpell.health + (player.spellPower * player.spellSellected.healPower);
        }
    }

    public virtual IEnumerator CdVisualize(float time)
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

}
