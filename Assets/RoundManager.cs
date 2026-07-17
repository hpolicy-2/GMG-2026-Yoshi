using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject[] attacks;
    public Transform gridTransform;
    private GameObject currentAttack;
    private bool roundOver;
    public GameObject player;
    void Start()
    {
        StartCoroutine(RoundLoop());
    }

    IEnumerator RoundLoop()
    {
        while (true)
        {
           
            roundOver = false;

            int attackNumber = Random.Range(0, attacks.Length); //generate random number form 0-# of attacks

            currentAttack = Instantiate(attacks[attackNumber], Vector3.zero, Quaternion.identity); //spawn random attack
            currentAttack.transform.parent = gridTransform;
          
            float timer = 5f; // length of each round

            while (timer > 0f && !roundOver)
            {
              
                timer -= Time.deltaTime; // subtrack the amount of time that has passed from the timer variable
                yield return null; //exit out of the while loop
            }
        
            Destroy(currentAttack); //destroy the active level
        }
    }

    public void EnemyDefeated()
    {
        roundOver = true;
    }
}