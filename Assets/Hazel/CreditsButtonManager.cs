using System;
using UnityEngine;

public class CreditsButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsButtons;
    [SerializeField] private Transform creditBoundary;
    [SerializeField] private GameObject creditsContainer;
    private bool isScrolling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isScrolling = true;
        creditsButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (creditsContainer != null)
        {
            ScrollCheck();
        }

        
    }

    private void ScrollCheck()
    {
        if (creditBoundary.position.y > (Screen.height))
        {
            creditsButtons.SetActive(true);
            Destroy(creditsContainer);
            return;
        }
        
    }
}
