using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController3D controller;
    public CameraShake shake;

    [SerializeField] private Transform slashSpawnPoint;
    [SerializeField] private GameObject slashPrefab;

    public float playerDMG = 10f;

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
            //LightAttack();
            StartCoroutine(SlashCoroutine());
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
