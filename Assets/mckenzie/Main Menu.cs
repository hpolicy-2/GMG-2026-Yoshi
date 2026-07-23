using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip playSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.PlayMusic(mainMenuMusic);
    }
    public void LoadSafeRoom()
    {
        SoundManager.Instance.PlaySFX(playSound);
        SceneManager.LoadScene("Safe Room");
    }
    
    public void QuitGame() { Application.Quit(); }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
