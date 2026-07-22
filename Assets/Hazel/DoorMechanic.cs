using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject interactPrompt;
    private bool playerInRange = false;
    private bool isLocked = true;

    public void SetLocked(bool locked)
    {
        isLocked = locked;
        if (isLocked && interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !isLocked && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isLocked && interactPrompt != null)
                interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactPrompt != null)
                interactPrompt.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);

        FindFirstObjectByType<SafeRoomController>().OnDoorOpened();
    }
}