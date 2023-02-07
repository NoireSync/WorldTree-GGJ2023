using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private ACoins coins;

    [SerializeField] private GameObject playerGameObject;

    [SerializeField] private PlayerAttack playerAttack;
    public int atkDmgUpgrade;
    public int atkDmgCost;
    public bool atkDmgUpgraded;

    [SerializeField] private PlayerController3D playerController3D;
    public float dashUpgrade;
    public int dashCost;
    public bool dashUpgraded;

    [SerializeField] private PlayerHealth playerHealth;
    public int hpUpgrade;
    public int hpCost;
    public bool hpUpgraded;

    public GameObject upgradeCanvasObj;
    public bool upgradeCanvasActive = false;

    [SerializeField] private GameObject resetPosObj;

    private void Awake()
    {
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        playerController3D = GameObject.Find("Player").GetComponent<PlayerController3D>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        playerGameObject = GameObject.Find("Player");
        resetPosObj = GameObject.Find("Reset Player Pos");
    }

    void Start()
    {
        atkDmgCost = 100;
        dashCost = 50;
        hpCost = 100;

        atkDmgUpgrade = 10;
        hpUpgrade = 30;
        dashUpgrade = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (atkDmgUpgraded)
        {
            atkDmgUpgrade = 15;
        }
        else { atkDmgUpgrade = 10; }

        if (hpUpgraded)
        { 
            hpUpgrade = 50;
        }
        else { hpUpgrade = 30; }

        if (dashUpgraded)
        {
            dashUpgrade = 5f;
        }
        else { dashUpgrade = 10f; }

        if (playerHealth.playerDied)
        {
            // popup canvas
            Time.timeScale = 0;
            ShowUpgradeCanvas();
        }
    }

    // Upgrade canvas n Buttons n set upgrade bools
    // buttn to reset n unpause 
    public void ShowUpgradeCanvas()
    { 
        upgradeCanvasObj.SetActive(true);
        upgradeCanvasActive = true;
    }

    public void UpgradeAtkBttn()
    {
        if (coins.points >= atkDmgCost)
        {
            coins.points -= atkDmgCost;
            atkDmgUpgraded = true;
            //this.GetComponent<Button>().interactable = false;
        }
        
    }
    public void UpgradeDashBttn()
    {
        if(coins.points >= dashCost)
        {
            coins.points -= dashCost;
            dashUpgraded = true;
            //this.GetComponent<Button>().interactable = false;
        }
    }
    public void UpgradeHpBttn()
    {
        if(coins.points >= hpCost)
        {
            coins.points -= hpCost;
            hpUpgraded = true;
            //this.GetComponent<Button>().interactable = false;
        }
    }
    public void ContinueBttn()
    {
        playerHealth.playerDied = false;
        upgradeCanvasObj.SetActive(false);
        upgradeCanvasActive = false;


        // Re-activate player game object
        playerGameObject.SetActive(true);
        // reset player transform NOT WORKING
        playerGameObject.transform.position = resetPosObj.transform.position;
        Time.timeScale = 1;
    }
}
