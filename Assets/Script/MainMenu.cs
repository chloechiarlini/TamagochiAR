using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "SampleScene";
    public AudioSource clickSound;
    public AudioSource backgroundMusic;

    void Start()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    public void PlayARScene()
    {
        if (clickSound != null)
            clickSound.Play();
       LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitApp()
    {
        Debug.Log("Quitter !");
        Application.Quit();
    }
}
