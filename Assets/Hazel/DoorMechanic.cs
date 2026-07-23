using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    [SerializeField] private GameObject interactPrompt;
    private bool playerInRange = false;
    private bool isLocked = true;
    [SerializeField] private AudioClip doorOpenSound;

    public void SetLocked(bool locked)
    {
        isLocked = locked;

        if (interactPrompt != null)
            interactPrompt.SetActive(!isLocked && playerInRange);
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
        
        SoundManager.Instance.PlaySFX(doorOpenSound);
        FindFirstObjectByType<SafeRoomController>().OnDoorOpened();
    }
}