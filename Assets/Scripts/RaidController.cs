using UnityEngine;

public class RaidController : MonoBehaviour
{
    public int groupsCount = 4;
    public int playersCount = 5;
    public bool allDead;
    public RaidMember[,] allRaid;
    public GameObject gameOverScreen;
    public Sprite spriteTank, spriteHeal, spriteDps;
    public enum Role { tank, healer, dps };

    public bool isStarted;
    public Boss boss;

    void Awake()
    {
        isStarted = false;
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

    void Update()
    {
        if (isStarted)
        {
            CheckAllRaidDeath();
            boss.BossFunction();
        }
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
