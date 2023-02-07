using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GolemAI golemAI;
    [SerializeField] private ACoins coins;

    public GameObject golemGameObj;

    private float dazedTime;
    public float startDazedTime;

    public int startingEnemyHealth;
    public int currentEnemyHealth;

    int hurtamountFromPlayer;

    public int aCoins;

    private void Awake()
    {
        golemAI = GameObject.Find("Golem").GetComponent<GolemAI>();
        golemGameObj = GameObject.Find("Golem");
    }

    private void Start()
    {
        startingEnemyHealth = Random.Range(20, 40);
        currentEnemyHealth = startingEnemyHealth;

        aCoins = Random.Range(5, 20);
    }

    private void Update()
    {
        if (dazedTime <= 0)
        {
            // Dont change enemy speed
            golemAI.currentMoveSpeed =golemAI.moveSpeed;
        }
        else
        {
            golemAI.currentMoveSpeed = 0;
            dazedTime -= Time.deltaTime;
        }

        // Remove after enemy ai fixed
        if (currentEnemyHealth <= 0)
        {
            golemAI.golemAnimator.SetBool("doDie", true);
            Debug.Log("Enemy dead");
            coins.points += aCoins ;
            DestroyThisObj();
            //Invoke("DestroyThisObj", 1f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slash")
        {
            //Debug.Log("Enemy hit");
            TakeDamage(hurtamountFromPlayer);
        }
    }
    public void TakeDamage(int amount)
    {
        dazedTime = startDazedTime;
        currentEnemyHealth -= amount;
        //ShowText(); //Damage popups not working correctly

        if (currentEnemyHealth <= 0)
        {
            golemAI.golemAnimator.SetBool("doDie", true);
            Debug.Log("Enemy dead");
            aCoins += coins.points;
            DestroyThisObj();
            //Invoke("DestroyThisObj", 1f);
        }
    }

    private void DestroyThisObj()
    {
        Destroy(golemGameObj);
    }
}
