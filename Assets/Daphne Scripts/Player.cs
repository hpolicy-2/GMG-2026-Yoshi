using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private float shakeForce = 1f;

    public float Health,
    MaxHealth;
    [SerializeField] private HealthBarUI healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void setHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }

    public void TakeDamage(int amount)
    {
        setHealth(- amount);
        SoundManager.Instance.PlaySFXRandomPitch(playerHurtSound);

        ShakeCamera();
        Debug.Log("Player hit by " + amount + "!");
        if (Health <= 0)
        {
            MainGameManager.Instance.OnPlayerDeath();
            Destroy(gameObject);
        }

    }




    

    // Call this from your existing damage method
 
    private void ShakeCamera()
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse(shakeForce);
        }
    }
}


