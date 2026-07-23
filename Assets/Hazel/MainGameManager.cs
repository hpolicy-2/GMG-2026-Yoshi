using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance { get; private set; }



    public int deathCount = 0;
    [SerializeField] private float healthReductionPerDeath = 0.2f;
    [SerializeField] private float minimumHealthPercent = 0.1f; // never go below 10% heaht

    public AudioClip safeRoomMusic;
    public AudioClip victoryMusic;
    public AudioClip gameOverMusic;
    public AudioClip combatMusic;
    public AudioClip menuMusic;


    public float musicFadeDuration = 1.5f;

    public bool firstDoorCutscenePlayed = false;
    public DialogueData firstDoorCutsceneDialogue;



    public DialogueData introDialogue;
    public List<DialogueData> deathDialoguePool; // random death dialogue
    public DialogueData finalVictoryDialogue;

    private List<DialogueData> unusedDeathDialogues = new List<DialogueData>();
    public DialogueData PendingDialogue { get; private set; } 

    [Header("Combat Levels")]
    public List<string> combatSceneNames; // listing scene names in an array within the game manager object
    public string gameOverSceneName = "Game Over";
    public string safeRoomSceneName = "Safe Room";

    public void OnPlayerDeath()
    {
        deathCount++;
        PendingDialogue = GetRandomUnusedDeathDialogue();
        SoundManager.Instance.PlayMusic(MainGameManager.Instance.gameOverMusic, MainGameManager.Instance.musicFadeDuration);

        SceneManager.LoadScene("Game Over"); 
    }

    public void ContinueToSafeRoom()
    {
        SceneManager.LoadScene("Safe Room");
        if (deathCount > 0)
        {
            
        }
    }

    public bool EnemyDefeated { get; private set; } = false;

    public void OnEnemyDefeated()
    {
        EnemyDefeated = true; // <-- this line was missing
        PendingDialogue = finalVictoryDialogue;
        SoundManager.Instance.PlayMusic(victoryMusic, musicFadeDuration); // set victory music here, once, at the source of truth
        SceneManager.LoadScene("Safe Room");
    }

    

    private void Awake()
    {
        if (deathCount == 0)
        {
          
        }
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ResetDialoguePool();
    }

    private void ResetDialoguePool()
    {
        unusedDeathDialogues = new List<DialogueData>(deathDialoguePool);
    }

    public float GetEnemyHealthPercent()
    {
        float percent = 1f - (deathCount * healthReductionPerDeath);
        return Mathf.Max(percent, minimumHealthPercent);
    }

  
    private DialogueData GetRandomUnusedDeathDialogue()
    {
        if (unusedDeathDialogues.Count == 0)
            ResetDialoguePool(); //reshuffle

        int index = Random.Range(0, unusedDeathDialogues.Count);
        DialogueData chosen = unusedDeathDialogues[index];
        unusedDeathDialogues.RemoveAt(index);
        return chosen;
    }

    // player opens door
    public void EnterCombat()
    {
        SoundManager.Instance.PlayMusic(MainGameManager.Instance.combatMusic, MainGameManager.Instance.musicFadeDuration);
        string chosenLevel = combatSceneNames[Random.Range(0, combatSceneNames.Count)];
        SceneManager.LoadScene(chosenLevel);
    }

    // called by saferoom script
    public DialogueData GetDialogueForThisVisit()
    {
        if (deathCount == 0 && !EnemyDefeated)
        {
            return introDialogue;
        }
        else if (EnemyDefeated)
        {
            return finalVictoryDialogue;
        }
        return PendingDialogue;
    }
}