using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance { get; private set; }

    public int deathCount = 0;
    [SerializeField] private float healthReductionPerDeath = 0.2f;
    [SerializeField] private float minimumHealthPercent = 0.1f; // never go below 10% heaht

   
    public DialogueData introDialogue;
    public List<DialogueData> deathDialoguePool; // random death dialogue
    public DialogueData finalVictoryDialogue;

    private List<DialogueData> unusedDeathDialogues = new List<DialogueData>();
    public DialogueData PendingDialogue { get; private set; } // set before loading safe room

    [Header("Combat Levels")]
    public List<string> combatSceneNames; // all scene names
    public string safeRoomSceneName = "SafeRoom";

    public bool EnemyDefeated { get; private set; } = false;

    private void Awake()
    {
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

    public void OnPlayerDeath()
    {
        deathCount++;
        PendingDialogue = GetRandomUnusedDeathDialogue();
        SceneManager.LoadScene(safeRoomSceneName);
    }

    public void OnEnemyDefeated()
    {
        EnemyDefeated = true;
        PendingDialogue = finalVictoryDialogue;
        SceneManager.LoadScene(safeRoomSceneName);
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
        string chosenLevel = combatSceneNames[Random.Range(0, combatSceneNames.Count)];
        SceneManager.LoadScene(chosenLevel);
    }

    // called by saferoom script
    public DialogueData GetDialogueForThisVisit()
    {
        if (deathCount == 0 && !EnemyDefeated)
            return introDialogue;

        return PendingDialogue;
    }
}