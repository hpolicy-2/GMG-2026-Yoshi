using UnityEngine;

public class creditsScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float scrollSpeed = 40f;

    private RectTransform rectTransform;

    void Start()
    {
        // Get the RectTransfrom component of the UI element
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Move the text upwards over time
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

    }
}
