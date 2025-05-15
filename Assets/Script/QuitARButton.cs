using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitARButton : MonoBehaviour
{
    public string sceneToLoad = "MainMenu";
    public AudioSource clickSound;

    public void QuitToMainMenu()
    {
        if (clickSound != null)
            clickSound.Play();

        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}