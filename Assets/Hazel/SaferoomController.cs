using UnityEngine;

public class SafeRoomController : MonoBehaviour
{
    [SerializeField] private DialogueUIManager dialogueUI;
    [SerializeField] private GameObject door;

    private void Start()
    {
        door.SetActive(false); //lock dfoor during dialogue

        DialogueData toPlay = MainGameManager.Instance.GetDialogueForThisVisit();
        dialogueUI.PlayDialogue(toPlay);
    }

    private void Update()
    {
        if (dialogueUI.IsFinished && !door.activeSelf)
        {
            door.SetActive(true);
        }
    }


    public void OnDoorOpened()
    {
        if (MainGameManager.Instance.EnemyDefeated)
        {
            // enemy is already dead
            return;
        }
        MainGameManager.Instance.EnterCombat();
    }
}