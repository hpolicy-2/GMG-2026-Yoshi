using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    [SerializeField] private float baseMaxHealth = 100f;
    private float currentHealth;

    public int health;
    public ParticleSystem enemyDamageFX;
    public EnemyHealthBarUI healthBarUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        float percent = MainGameManager.Instance.GetEnemyHealthPercent();
        currentHealth = baseMaxHealth * percent;

        healthBarUI.SetHealth(currentHealth);
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void damageEnemy(float amount)
    {
        enemyDamageFX.Play();

        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }

    }
    private void Die()
    {
        MainGameManager.Instance.OnEnemyDefeated();
    }

}   


