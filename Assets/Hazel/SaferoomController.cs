using UnityEngine;
using System.Collections;

public class SafeRoomController : MonoBehaviour
{
    [SerializeField] private DialogueUIManager dialogueUI;
    [SerializeField] private DoorMechanic door;
    [SerializeField] private GameObject blackScreenOverlay;
    [SerializeField] private GameObject lovieCharacterSprite;
    [SerializeField] private GameObject clickToContinueNotice;
    private void Start()
    {
        PlaySafeRoomMusic();
        if (MainGameManager.Instance == null)
        {
            clickToContinueNotice.SetActive(true);
            Debug.LogWarning("GameManager not found — are you testing this scene directly instead of from Main Menu?");
            return;
        }

        door.SetLocked(true);

        UpdateAllyVisibility();

        DialogueData toPlay = MainGameManager.Instance.GetDialogueForThisVisit();
        dialogueUI.PlayDialogue(toPlay);
    }
    private void Update() 
    { 
        if (dialogueUI.IsFinished) 
        { 
            door.SetLocked(false); 
        } 
    }
    private void UpdateAllyVisibility()
    {
        bool shouldShow = MainGameManager.Instance.deathCount >= 1;
        lovieCharacterSprite.SetActive(shouldShow);
    }

    private void PlaySafeRoomMusic()
    {
        SoundManager.Instance.PlayMusic(MainGameManager.Instance.safeRoomMusic, MainGameManager.Instance.musicFadeDuration);
    }

    public void OnDoorOpened()
    {
        if (MainGameManager.Instance.EnemyDefeated) return;
        clickToContinueNotice.SetActive(false);

        if (!MainGameManager.Instance.firstDoorCutscenePlayed)
        {
            StartCoroutine(PlayFirstDoorCutscene());
        }
        else
        {
            MainGameManager.Instance.EnterCombat();
        }
    }

    private IEnumerator PlayFirstDoorCutscene()
    {
        door.SetLocked(true);
        blackScreenOverlay.SetActive(true);

        SoundManager.Instance.PlayMusic(MainGameManager.Instance.gameOverMusic, MainGameManager.Instance.musicFadeDuration);
        dialogueUI.PlayDialogue(MainGameManager.Instance.firstDoorCutsceneDialogue);

        yield return new WaitUntil(() => dialogueUI.IsFinished);

        blackScreenOverlay.SetActive(false);
        MainGameManager.Instance.firstDoorCutscenePlayed = true;
        MainGameManager.Instance.EnterCombat();
    }
}