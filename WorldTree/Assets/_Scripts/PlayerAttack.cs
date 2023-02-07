using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: This script controls player's attack logic

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;

    [SerializeField] private PlayerController3D controller;
    
    [SerializeField] private CameraShake shake;

    [SerializeField] private Transform slashSpawnPoint;
    [SerializeField] private GameObject slashPrefab;

    public int playerDMG;

    public float timeBetweenPress = .5f;
    private float timestamp;


    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = GameObject.Find("Upgrade Mangaer").GetComponent<UpgradeManager>();
        
        playerDMG = upgradeManager.atkDmgUpgrade;
    }

    // Update is called once per frame
    void Update()
    {
        playerDMG = upgradeManager.atkDmgUpgrade;

        if (Time.time >= timestamp && Input.GetMouseButtonDown(0))
        {
            // Left click
            //LightAttack();
            StartCoroutine(SlashCoroutine());
            timestamp = Time.time + timeBetweenPress;
        }
    }


    private IEnumerator SlashCoroutine()
    {
        shake.shouldShake = true;
        var slash = Instantiate(slashPrefab, transform.position, transform.rotation);  
        slash.GetComponent<Rigidbody>().velocity = slashSpawnPoint.forward;

        Destroy(slash,1);

        yield return null;
    }
}
