using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text speakerNameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private float typeSpeed = 0.02f;

    private DialogueData currentDialogue;
    private int lineIndex;
    private bool isTyping;
    public bool IsFinished { get; private set; }

    public void PlayDialogue(DialogueData data)
    {
        if (data == null || data.lines.Length == 0)
        {
            IsFinished = true;
            dialoguePanel.SetActive(false);
            return;
        }

        currentDialogue = data;
        lineIndex = 0;
        IsFinished = false;
        dialoguePanel.SetActive(true);
        ShowLine();
    }

    public void OnAdvancePressed()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentDialogue.lines[lineIndex].text;
            isTyping = false;
            return;
        }

        lineIndex++;
        if (lineIndex >= currentDialogue.lines.Length)
        {
            dialoguePanel.SetActive(false);
            IsFinished = true;
            return;
        }
        ShowLine();
    }

    private void ShowLine()
    {
        var line = currentDialogue.lines[lineIndex];
        speakerNameText.text = line.speakerName;
        portraitImage.sprite = line.portrait;
        StopAllCoroutines();
        StartCoroutine(TypeText(line.text));
    }

    private System.Collections.IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
        isTyping = false;
    }
}