using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;

    [SerializeField] private int currentMaxHealth = 30;
    [SerializeField] private int currentHealth;

    //bool damaged;

    public HealthBar healthBar;

    public int dmgTaken;

    public bool playerDied = false;

    void Start()
    {
        upgradeManager = GameObject.Find("Upgrade Mangaer").GetComponent<UpgradeManager>();

        currentMaxHealth = upgradeManager.hpUpgrade;
        currentHealth = currentMaxHealth;
        healthBar.SetMaxHealth(currentMaxHealth);
    }

    void Update()
    {
        if (upgradeManager.hpUpgraded)
        {
            UpdateHp();
        }
    }

    private void UpdateHp()
    {
        currentMaxHealth = upgradeManager.hpUpgrade;
        currentHealth = currentMaxHealth;
        healthBar.SetMaxHealth(currentMaxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Golem")
        {
            TakeDamage(dmgTaken);
        }
    }
    public void TakeDamage(int dmgTaken)
    {

        //Debug.Log("I was hit!");
        currentHealth -= dmgTaken;
        //damaged = true;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        playerDied = true;
        this.gameObject.SetActive(false);
    }

}
