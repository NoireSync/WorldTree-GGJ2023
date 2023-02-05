using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCollision : MonoBehaviour
{
    public EnemyHealth eHealth;
    public PlayerAttack dmg;


    private void Awake()
    {
        eHealth = GameObject.Find("Golem").GetComponent<EnemyHealth>();
        dmg = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Golem")
        {
            if (other != null)
            {
                Debug.Log("Slashes");
                eHealth.enemyHealth -= dmg.playerDMG;
            }
        }
    }
}
