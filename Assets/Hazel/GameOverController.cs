using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void OnRestartButtonPressed()
    {
        Application.LoadLevel(0);
    }
}