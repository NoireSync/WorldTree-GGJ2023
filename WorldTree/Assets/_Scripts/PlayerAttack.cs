using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerController3D controller;

    [SerializeField] private Transform slashSpawnPoint;
    [SerializeField] private GameObject slashPrefab;

    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Left click
            LightAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            // Right click
            ProjectileAttack();
        }
    }

    private void LightAttack()
    {
        
    }
    private void ProjectileAttack()
    {
        //var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

    
}
