using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public float costMana;
    public float castTime;
    public float cooldown;
    public float healPower;
    public float durationEffect;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    /*
    public void FlashHeal()
    {
        // leczy jedna osobe
        costMana = 3f;
        castTime = 1.5f;
        globalCD = 1.5f;
        cooldown = 0f;
        healPower = 1.35f;
        durationEffect = 0f;

    }
    public void Heal()
    {
        // leczy jena osobe
        costMana = 1.9f;
        castTime = 2.5f;
        globalCD = 1.5f;
        cooldown = 0f;
        healPower = 1.75f;
        durationEffect = 0f;

    }
    public void Renew()
    {
        // leczy co 3s
        costMana = 1.8f;
        castTime = 0f;
        globalCD = 1.5f;
        cooldown = 0f;
        healPower = 0.23f;
        durationEffect = 15f;
    }
    public void DispelMagic()
    {
        // niweluje negatywny efekt
        costMana = 1.6f;
        castTime = 0f;
        globalCD = 1.5f;
        cooldown = 0f;
        healPower = 0f;
        durationEffect = 0f;
    }
    public void PrayerOfMending()
    {
        // naklada 5 stackow - leczy jak dostanie obrazenia i przechodzi dalej
        costMana = 2f;
        castTime = 1.5f;
        globalCD = 1.5f;
        cooldown = 12f;
        healPower = 0.45f;
        durationEffect = 30f;
    }
    public void PrayerOfHealing()
    {
        // leczy party
        costMana = 4.5f;
        castTime = 2f;
        globalCD = 1.5f;
        cooldown = 0f;
        healPower = 0.63f;
        durationEffect = 0f;
    }
    public void DivineHymn()
    {
        // leczy wszystkich 5x wciagu 8s
        costMana = 4.4f;
        castTime = 8f;
        globalCD = 1.5f;
        cooldown = 180f;
        healPower = 0.45f;
        durationEffect = 0f;
    }
    public void HolyWordSerenity()
    {
        // leczy jedna osobe, cooldown zbijamy flashhealem i healem o 6s
        costMana = 4f;
        castTime = 0f;
        globalCD = 1.5f;
        cooldown = 60f;
        healPower = 5f;
        durationEffect = 0f;
    }
    public void HolyWordSanctify()
    {
        // leczy party, cooldown zbijamy PrayerofHealing o 6s i renew o 2s
        costMana = 5f;
        castTime = 0f;
        globalCD = 1.5f;
        cooldown = 60f;
        healPower = 1.75f;
        durationEffect = 0f;
    }
    */
}
