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

    public float damage;
    public float attackSpeed;
    private float attackCooldown = 2;
    private float timeNextAttack;

    public Boss boss;

    public bool debuffIsActive = false;
    public GameObject debuffIndicator;
    public Coroutine debuffCoroutine;

    public GameObject pomIndicator;
    public Text pomStacksText;


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        health = maxHealth;
        UpdateRaidBar();
        
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
                isAlive = false;
            }
            if (health > maxHealth)
                health = maxHealth;

            UpdateRaidBar();
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
            boss.health -= damage;
        }
    }
}
