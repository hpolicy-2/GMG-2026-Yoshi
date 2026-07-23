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

    private void Start()
    {
        float percent = MainGameManager.Instance.GetEnemyHealthPercent();
        currentHealth = baseMaxHealth * percent;

        healthBarUI.SetMaxHealth(currentHealth); // set max
        healthBarUI.SetHealth(currentHealth);
    }

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
        healthBarUI.SetHealth(currentHealth); // update bar

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