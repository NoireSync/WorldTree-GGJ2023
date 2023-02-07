using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

// NOTE: This script only controls enemy STATES (movement, collisions, damage)
// Todo so it needs a reference to the player's position  
public class GolemAI : MonoBehaviour
{
    /* NOTE - More states can be added or removed */
    public enum STATES
    {
        ROAMING,
        CHASING,
        ATTACKING
        // RETREATING
    }

    // State variable
    public STATES _currentState;

    [SerializeField] private PlayerController3D playerController;
    [SerializeField] private PlayerHealth playerHealth;

    public NavMeshAgent agent;

    public Transform playerTarget;

    public Animator golemAnimator;

    public float moveSpeed;
    public float currentMoveSpeed;

    public float distance;

    // Roaming
    public bool isRoaming = false;

    // MIGHT NOT USE
    public float roamRange; //radius of sphere
    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    // Chasing
    public float chaseRange;

    //Attacking
    public int enemyDMG;
    bool canAttack = true;
    public bool isAttacking = false;
    public float attackRange;
    public float timeBetweenAtks;

    private void Awake()
    {
        _currentState = STATES.ATTACKING;

        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        playerController = GameObject.Find("Player").GetComponent<PlayerController3D>();

        playerTarget = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        enemyDMG = Random.Range(3, 7);

        chaseRange = 7f;
        attackRange = 1.5f;

        moveSpeed = 10f;
        currentMoveSpeed = moveSpeed;

        isRoaming = true;
    }


    private void Update()
    {

        switch (_currentState)
        {
            case STATES.ROAMING:
                DistanceCheck();

                //if (agent.remainingDistance <= agent.stoppingDistance) //done with path
                //{
                //    Vector3 point;

                //    if (RandomPoint(centrePoint.position, roamRange, out point)) //pass in our centre point and radius of area
                //    {
                //        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                //        agent.SetDestination(point);
                //    }
                //}

                break;

            case STATES.CHASING:

                //transform.LookAt(playerTarget);
                //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);

                transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, currentMoveSpeed * Time.deltaTime);

                // ATTACKING
                if (distance <= attackRange)
                {
                    isAttacking = true;
                    isRoaming = false;
                    //golemAnimator.SetBool("doAttack", true);
                    //transform.LookAt(playerTarget);
                    //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);

                    _currentState = STATES.ATTACKING;
                }

                // ROAMING
                if (!isAttacking && distance > chaseRange && distance > attackRange)
                {
                    isRoaming = true;
                    _currentState = STATES.ROAMING;
                }

                break;

            case STATES.ATTACKING:

                // ATTACKING
                if (canAttack)
                {

                    playerHealth.TakeDamage(enemyDMG);
                    canAttack = false;
                    Invoke("CanAttack", 1f);
                }
                // CHASING
                if (distance >= attackRange && distance <= chaseRange)
                {
                    isAttacking = false;
                    isRoaming = false;
                    _currentState = STATES.CHASING;
                }
                // ROAMING
                if (distance > attackRange && distance > chaseRange)
                {
                    isAttacking = false;
                    isRoaming = true;
                    _currentState = STATES.ROAMING;
                }

                break;
        }
    }

    private void DistanceCheck()
    {
        distance = Vector3.Distance(playerTarget.position, transform.position);
    }

    public void CanAttack()
    {
        canAttack = true;
    }

    //// Roaming
    //bool RandomPoint(Vector3 center, float range, out Vector3 result)
    //{

    //    Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
    //    NavMeshHit hit;
    //    if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
    //    {
    //        //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
    //        //or add a for loop like in the documentation
    //        result = hit.position;
    //        return true;
    //    }

    //    result = Vector3.zero;
    //    return false;
    //}


}
