using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float speed = 5f;

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashTime = .25f;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float resetTime = 5f;

    [SerializeField] private Vector3 move;


    [SerializeField] private bool isDashing;
    [SerializeField] private bool dashOnCoolDown;
    

    private void Start()
    {
        //_rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();

        currentTime = resetTime;

    }

    private void Update()
    {
        // Changed input settings to refect iso movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = new Vector3(horizontal, 0, vertical);
        characterController.Move(move * speed * Time.deltaTime);
        //_rb.AddForce( move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !dashOnCoolDown)
        {
            //Can only dash if moving
            StartCoroutine(DashCoroutine(move));
        }

        /*if (isDashing)
        {
           StartCoroutine(DashCoroutine());
        }*/

        if (dashOnCoolDown)
        {
            Debug.Log("Dash On Cooldown!");
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                Debug.Log("Dash Reset!");
                currentTime = resetTime;
                dashOnCoolDown = false;
            }
        }
       
    }

    private IEnumerator DashCoroutine(Vector3 direction)
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        while (Time.time < startTime + dashTime)
        {
            // Add screenShake
            characterController.Move(direction * dashSpeed * Time.deltaTime);
            
            //isDashing = false;

            dashOnCoolDown = true;

            // disable and re-enable collider 

            yield return null; // this will make Unity stop here and continue next frame
        }
    }

}

