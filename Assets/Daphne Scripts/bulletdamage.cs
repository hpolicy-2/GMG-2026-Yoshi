using UnityEngine;

public class bulletdamage : MonoBehaviour
{
    public int bulletDamage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemyhealth>().damageEnemy(bulletDamage);
            Destroy(gameObject);
        }

    }
}
