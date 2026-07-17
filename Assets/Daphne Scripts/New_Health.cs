using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class New_Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
