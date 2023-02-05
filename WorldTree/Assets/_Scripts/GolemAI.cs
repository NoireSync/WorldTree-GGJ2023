using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important


public class GolemAI : MonoBehaviour
{
    public PlayerController3D playerController;

    public NavMeshAgent agent;
    public Transform playerTarget;

    public PlayerHealth pHealth;
    public EnemyHealth eHp;
    public int enemyDMG;

    public Animator golemAnimator;

    float timer;
    int rng;


    public bool isRoaming = false;
    public bool isAttacking = false;
    public float moveSpeed = 10f;
    public float distance;

    // Roaming
    public float roamRange; //radius of sphere
    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    // Chasing
    public float chaseRange = 5f;

    //Attacking
    public float attackRange = 5f;
    public float timeBetweenAtks;


    public int Acoins;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.Find("Player").transform;

        enemyDMG = Random.Range(5, 12);

        Acoins = Random.Range(5, 20);
        chaseRange = 5f;
        attackRange = 5f;

        isRoaming = true;
    }


    void Update()
    {
        distance = Vector3.Distance(playerTarget.position, transform.position);

        if (isRoaming)
        { // Roaming
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;

                if (RandomPoint(centrePoint.position, roamRange, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
        }

        if (distance <= chaseRange)
        {
            isRoaming = false;
            transform.LookAt(playerTarget);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed );
        }
        else isRoaming = true;
         
        if (distance <= 1.5f)
        {
            isAttacking = true;
            isRoaming = false;
            golemAnimator.SetBool("doAttack", true);

        }
        else isRoaming = true;

        if (eHp.dropAcorns)
        {
            Acoins += playerController.points;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other != null)
            {
                Debug.Log("Player - ");
                pHealth.currentHP -= enemyDMG;
            }
        }
    }


    // Roaming
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}
