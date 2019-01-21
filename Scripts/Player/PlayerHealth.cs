using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        
    }

    //public void DoDamage(int dmg)
    //{
    //    currentHealth -= dmg;
    //    SimpleHealthBar.UpdateBar("HealthBar", currentHealth, maxHealth);

    //}

    public void DamagePlayer(int dmg, Vector3 direction)
    {
        currentHealth -= dmg;
        SimpleHealthBar.UpdateBar("HealthBar", currentHealth, maxHealth);

        if (currentHealth == 0)
        {
            Application.LoadLevel("MainMenu");
        }

    }



}

