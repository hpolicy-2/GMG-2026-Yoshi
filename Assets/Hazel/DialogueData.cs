using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Scene")]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public struct Line
    {
        public string speakerName;
        public Sprite portrait;
        [TextArea(2, 5)]
        public string text;
        public AudioClip typingSound;
    }

    public Line[] lines;
}