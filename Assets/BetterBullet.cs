using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterBullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] private HealthSystem enemyHealthSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthSystem EnemyHealthSystem = GetCompenent<HealthSystem>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotations = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotations.y, rotations.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Enemy Hit!!!
            Destroy(gameObject);

        }

        Destroy(gameObject, 5f);
    }

}
