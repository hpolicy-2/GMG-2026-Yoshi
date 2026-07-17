using UnityEngine;


public class FiringScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject enemy;
    private Vector3 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePos = Input.mousePosition;
            BulletFire();

        }
    }


    void BulletFire()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = gameObject.transform.position;
        newBullet.transform.rotation = Quaternion.identity;

    }
}

