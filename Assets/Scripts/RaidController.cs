using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidController : MonoBehaviour
{
    public RaidMember mainTank;
    public RaidMember offTank;

    public RaidMember[,] allRaid;

    public int groupsCount = 4;
    public int playersCount = 5;

    // dodac podzial na hilera dpsa i tanka, gracz bedzie jednym z healerow - jak zginie nie moze hilac, 
    // ale istnieje mozliwosc że ktoś go wskrzesi lub otrzyma aniolka z talentow a z przedmiotem legendarnym po skonczeniu aniolka wskrzesi sie.

    public bool allDead;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        allDead = false;
        int tmp = 1;
        allRaid = new RaidMember[groupsCount, playersCount];

        for (int i = 0; i < groupsCount; i++)
        {
            for (int j = 0; j < playersCount; j++)
            {
                allRaid[i, j] = GameObject.Find("Player" + tmp).GetComponent<RaidMember>();
                tmp++;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        CheckAllRaidDeath();
    }

    public void CheckAllRaidDeath()
    {
        bool tmp=false;

        for (int i = 0; i < groupsCount; i++)
        {
            for (int j = 0; j < playersCount; j++)
            {
                if (allRaid[i, j].isAlive)
                {
                    tmp = true;
                    break;
                }
            }
        }
        if(!tmp)
        {
            allDead = true;
            gameOverScreen.SetActive(true);
        }
    }
}
