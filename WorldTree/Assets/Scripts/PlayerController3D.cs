using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float resetTime = 5f;

    [SerializeField] private Vector3 move;


    [SerializeField] private bool isDashing;
    [SerializeField] private bool dashOnCoolDown;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        currentTime = resetTime;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !dashOnCoolDown)
        {
            isDashing = true;
        }

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

    private void FixedUpdate()
    {
        // Changed input settings to refect iso movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = new Vector3(horizontal, 0, vertical);
        _rb.MovePosition(transform.position + move * Time.deltaTime * speed);

        if (isDashing)
        {
            _rb.MovePosition(transform.position + move * dashSpeed);
            isDashing = false;

            dashOnCoolDown = true;
        }
       
    }

   
}

