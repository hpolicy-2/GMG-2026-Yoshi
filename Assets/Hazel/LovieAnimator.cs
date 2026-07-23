using UnityEngine;

public class LovieAnimator : MonoBehaviour
{
    [SerializeField] private GameObject lovieModel;
    [SerializeField] private Animator breatheAnimation;

    private bool wasActive = false;

    void Update()
    {
        
        if (lovieModel != null && lovieModel.activeInHierarchy)
        {
            
            if (!wasActive)
            {
                breatheAnimation.Play("LovieBreathe");
                wasActive = true;
            }
        }
        else
        {
            wasActive = false;
        }
    }
}