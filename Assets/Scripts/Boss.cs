using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public HealthBar healthBar;

    public Text healthText;

    public bool isAlive;

    public RaidMember target;
    public float changeTargetCooldown;
    private float timeToChangeTarget = -1;

    public RaidController raidController;

    public float damage;
    public float attackCooldown;
    private float timeNextAttack;

    public float aoeDamage;
    public float aoeAttackCooldown;
    private float timeNextAoeAttack;

    public Debuff debuff;
    private float timeNextDebuff;

    public GameObject victoryScreen;
    public string bossName;

    public int expReward;
    public int goldReward;
    public Player player;



    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        health = maxHealth;
        UpdateHealthBar();
        FocusTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && !raidController.allDead)
        {
            CheckDeath();
            UpdateHealthBar();
            DealDamage();
            DealAoeDamage();
            CastDebuff();
            if (!target.isAlive)
                timeToChangeTarget = 0;
            FocusTarget();
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.UpdateBar(health, maxHealth);
        healthText.text = ((health / maxHealth * 100).ToString("0") + "%");
        if (!isAlive)
            healthText.text = ("Dead");
    }

    public void CheckDeath()
    {
        if(health<=0)
        {
            health = 0;
            isAlive = false;
            healthText.text = "Dead";
            victoryScreen.SetActive(true);

            PlayerPrefs.SetFloat(bossName, 1);
            player.CheckPlayerLevel(expReward);
            PlayerGoldController.AddGold(goldReward);
            
        }
    }

    public void DealDamage()
    {
        if (Time.time > timeNextAttack )
        {
            timeNextAttack = Time.time + attackCooldown;

            if(target.role == RaidController.Role.tank)
                target.health -= damage;
            else
                target.health -= damage * 2;
        }
    }

    public void DealAoeDamage()
    {
        if (Time.time > timeNextAoeAttack)
        {
            timeNextAoeAttack = Time.time + aoeAttackCooldown;
            for (int i = 0; i < raidController.allRaid.GetLength(0); i++)
            {
                for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
                {
                    if (raidController.allRaid[i, j].isAlive)
                    {
                        raidController.allRaid[i, j].health -= aoeDamage;
                    }
                }
            }
        }
    }

    public void CastDebuff()
    {
        if (Time.time > timeNextDebuff)
        {
            int x = raidController.allRaid.GetLength(0);
            int y = raidController.allRaid.GetLength(1);
            int randomX = 0;
            int randomY = 0;
            
            do
            {
                randomX = Random.Range(0, x);
                randomY = Random.Range(0, y);      
            } while (raidController.allRaid[randomX, randomY].isAlive == false);
            
            timeNextDebuff = Time.time + debuff.cooldown;

            raidController.allRaid[randomX,randomY].debuffCoroutine = StartCoroutine(debuff.DebuffEffect(randomX, randomY));
        }     
    }

    public void FocusTarget()
    {
        if (Time.time > timeToChangeTarget)
        {
            int flag = 0;
            int randomI = 0;
            int randomJ = 0;

            for (int i = 0; i < raidController.allRaid.GetLength(0); i++)
            {
                for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
                {
                    if ((raidController.allRaid[i, j].isAlive) && (raidController.allRaid[i, j].role == RaidController.Role.tank) && (raidController.allRaid[i, j] != target))
                    {
                        target = raidController.allRaid[i, j];
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                    break;
            }
            if (flag == 0)
            {
                do
                {
                    randomI = Random.Range(0, raidController.allRaid.GetLength(0));
                    randomJ = Random.Range(0, raidController.allRaid.GetLength(1));
                } while ((!raidController.allRaid[randomI, randomJ].isAlive) && (raidController.allRaid[randomI, randomJ] != target));

                target = raidController.allRaid[randomI, randomJ];
            }

            timeToChangeTarget = Time.time + changeTargetCooldown;
        }


        
    }

}
