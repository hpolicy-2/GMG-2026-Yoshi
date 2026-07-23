using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void OnPersistButtonPressed()
    {
        Debug.Log("Persist pressed");
        MainGameManager.Instance.ContinueToSafeRoom();
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}