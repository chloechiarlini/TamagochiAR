using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadePanel : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 0.5f;

    public void StartFade(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private System.Collections.IEnumerator FadeAndLoadScene(string sceneName)
    {
        float t = 0;
        Color color = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}