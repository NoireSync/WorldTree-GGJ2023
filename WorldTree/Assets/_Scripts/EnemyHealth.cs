using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GolemAI golemAI;
    public float enemyHealth = 20f;
    public bool dropAcorns;

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            golemAI.golemAnimator.SetBool("doDie", true);
            dropAcorns = true;
            Destroy(this.gameObject);

            
        }
    }
}
