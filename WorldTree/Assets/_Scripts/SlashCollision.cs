using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: This script controls player's attack effect and damage logic

public class SlashCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth eHealth;
    [SerializeField] private PlayerAttack playerAttack;

    public int dmgAmount;

    private void Awake()
    {
        eHealth = GameObject.Find("Golem").GetComponent<EnemyHealth>();
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        dmgAmount = playerAttack.playerDMG;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Golem")
        {
            if (other != null)
            {
                eHealth.TakeDamage(dmgAmount);
                Debug.Log("Slashed Enemy");
            }
        }
    }
}
