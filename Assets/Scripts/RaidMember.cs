using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaidMember : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public HealthBar healthBar;

    public SpriteRenderer borderIndicator;
    public GameObject renewIndicator;
    public Coroutine renewCoroutine;

    public Text healthText;

    public bool isAlive;

    public float power;
    public float attackSpeed;
    public float attackCooldown;
    private float timeNextAttack;

    public Boss boss;

    public bool debuffIsActive = false;
    public GameObject debuffIndicator;
    public Coroutine debuffCoroutine;

    public GameObject pomIndicator;
    public Text pomStacksText;

    public RaidController.Role role;
    public GameObject roleIndicator;
    public RaidController raidController;


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        health = maxHealth;
        UpdateRaidBar();

        raidController = FindObjectOfType<RaidController>();

        switch (role)
        {
            case RaidController.Role.tank:
                roleIndicator.GetComponent<SpriteRenderer>().sprite = raidController.spriteTank;
                return;
            case RaidController.Role.healer:
                roleIndicator.GetComponent<SpriteRenderer>().sprite = raidController.spriteHeal;
                return;
            case RaidController.Role.dps:
                roleIndicator.GetComponent<SpriteRenderer>().sprite = raidController.spriteDps;
                return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if(health<=0)
            {
                health = 0;
                debuffIndicator.SetActive(false);
                renewIndicator.SetActive(false);
                pomIndicator.SetActive(false);
                isAlive = false;
            }
            if (health > maxHealth)
                health = maxHealth;

            UpdateRaidBar();
            if(role == RaidController.Role.healer)
                HealAlly();
            else
                DealDamage();
        }
    }

    public void UpdateRaidBar()
    {
        healthBar.UpdateBar(health, maxHealth);
        healthText.text = ((health / maxHealth * 100).ToString("0") + "%");
        if(!isAlive)
            healthText.text = ("Dead");
    }

    public void DealDamage()
    {
        if (Time.time > timeNextAttack && boss.isAlive)
        {
            timeNextAttack = Time.time + (attackCooldown - attackSpeed);
            boss.health -= power;
        }
    }

    public void HealAlly()
    {
        if (Time.time > timeNextAttack && boss.isAlive)
        {
            timeNextAttack = Time.time + (attackCooldown - attackSpeed);

            int randomGroup = Random.Range(0, 4);
            for(int i = 0; i < raidController.playersCount; i++)
            {
                if(raidController.allRaid[randomGroup, i].isAlive)
                {
                    raidController.allRaid[randomGroup, i].health = raidController.allRaid[randomGroup, i].health + power;
                }
            }
        }
    }
}
