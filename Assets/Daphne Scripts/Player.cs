using System.Collections;using System.Collections.Generic;using UnityEngine;public class Player : MonoBehaviour
{    public float Health,    MaxHealth;    [SerializeField] private HealthBarUI healthBar;

    // Start is called before the first frame update
    void Start()
    {        healthBar.SetMaxHealth(MaxHealth);    }

    // Update is called once per frame
    void Update()
    {                   }    public void setHealth(float healthChange)
    {        Health += healthChange;        Health = Mathf.Clamp(Health, 0, MaxHealth);        healthBar.SetHealth(Health);    }    public void TakeDamage(int amount)
    {
        setHealth(- amount);
        Debug.Log("Player hit by " + amount + "!");
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }}