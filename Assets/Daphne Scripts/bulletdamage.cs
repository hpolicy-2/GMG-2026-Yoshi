using UnityEngine;

public class bulletdamage : MonoBehaviour
{
    public float bulletDamage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MainEnemy")
        {
            other.gameObject.GetComponent<enemyhealth>().damageEnemy(bulletDamage);
            Destroy(gameObject);
        }

    }
}
