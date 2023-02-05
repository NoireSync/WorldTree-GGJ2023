using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerController3D controller3D;
    public Transform playerMoveScript;

    public int playerHealth = 50;
    public int maxHP;
    public int currentHP;

    public Slider slider;

    private void Start()
    {
        currentHP = playerHealth = 50;
    
}

    private void Update()
    {

        if (playerHealth <= 0)
        {
            controller3D.enabled = false;

            //Popup menu
            //restart
        }
    }

    public void SetHealth(int Hp)
    {
        Hp = playerHealth;
        slider.value = Hp;
    }

    public void MaxHp(int Hp)
    {
        Hp = playerHealth;
        slider.maxValue = Hp;
        slider.value = Hp;
    }
}
