using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    [SerializeField] private float baseMaxHealth = 100f;
    private float currentHealth;

    public int health;
    public ParticleSystem enemyDamageFX;
    public EnemyHealthBarUI healthBarUI;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;

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
        SoundManager.Instance.PlaySFX(hitSound);

        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }

    }
    private void Die()
    {
        SoundManager.Instance.PlaySFX(deathSound); 
        MainGameManager.Instance.OnEnemyDefeated();
    }

}   


