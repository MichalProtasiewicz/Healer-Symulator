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
    public RaidController raidController;

    public float damage;
    public float attackSpeed;
    private float attackCooldown = 2;
    private float timeNextAttack;

    public Debuff debuff;
    private float timeNextDebuff;

    public GameObject victoryScreen;
    public string bossName;



    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        health = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && !raidController.allDead)
        {
            CheckDeath();
            UpdateHealthBar();
            DealDamage();
            CastDebuff();
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
        }
    }

    public void DealDamage()
    {
        if (Time.time > timeNextAttack )
        {
            timeNextAttack = Time.time + (attackCooldown - attackSpeed);
            for(int i = 0; i < raidController.allRaid.GetLength(0); i++)
            {
                for (int j = 0; j < raidController.allRaid.GetLength(1); j++)
                {
                    if (raidController.allRaid[i, j].isAlive)
                    {
                        raidController.allRaid[i, j].health -= damage;
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
            RaidMember target;
            
            do
            {
                randomX = Random.Range(0, x );
                randomY = Random.Range(0, y );      
            } while (raidController.allRaid[randomX, randomY].isAlive == false);
            
            timeNextDebuff = Time.time + debuff.cooldown;

            raidController.allRaid[randomX,randomY].debuffCoroutine = StartCoroutine(debuff.DebuffEffect(randomX, randomY));
        }     
    }

    

}
