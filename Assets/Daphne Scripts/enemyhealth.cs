using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int health;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;

    }
}   
