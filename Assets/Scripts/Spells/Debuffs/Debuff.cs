using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    public float durationEffect;
    public float timeBetweenTick;
    public float healthDecrease;
    public float cooldown;

    public RaidController raidController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DebuffEffect(int cordinateX, int cordinateY)
    {
        float damageCdTimer = 0;

        RaidMember target = raidController.allRaid[cordinateX, cordinateY];

        target.debuffIsActive = true;
        target.debuffIndicator.SetActive(true);

        for (int i = 0; i < durationEffect; i++)
        {
            if (damageCdTimer == 0)
            {
                damageCdTimer = timeBetweenTick;
                target.health = target.health - healthDecrease;
            }
            damageCdTimer--;
            yield return new WaitForSeconds(1);
        }

        target.debuffIsActive = false;
        target.debuffIndicator.SetActive(false);
    }

}
