using UnityEngine;

public class RoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool isRoundActive = false;
    public GameObject[] attacks;


    void Start()
    {
        //Set starting health value
        //Wait for player input
        //isRoundActive = true

    }

    // Update is called once per frame
    void Update()
    {
   
       if (!isRoundActive)
        {
            //Wait for player input
            //Paste Round Choose Function
        }

    }

    void RoundPick()
    {
        //Pick random attack
        //Make that attack active
    }
    public void EnemyDefeated()
    {
        //isRoundActive = false
    }
}