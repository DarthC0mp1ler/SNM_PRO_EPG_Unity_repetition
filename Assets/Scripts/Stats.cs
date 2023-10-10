using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private int maxHealth = 100;
    private int health;

    public Image healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public void DecreaseHealth(int delta) 
    {
        health -= delta;
        if (health < 0)
        {
            health = 0;
        }
        if (health > maxHealth) 
        {
            health = maxHealth;
        }
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public bool IsAlive() 
    {
        return health > 0;
    }
   
}
