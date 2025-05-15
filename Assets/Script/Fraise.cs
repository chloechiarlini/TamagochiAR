using System.Collections;
using UnityEngine;

public class Fraise : MonoBehaviour
{
    public AudioSource eatSound;
    public FeedManager feedManager;

    void OnMouseDown()
    {
        if (eatSound != null) eatSound.Play();
        if (feedManager != null)
            feedManager.NotifyStrawberryEaten();
        
        StartCoroutine(RebondPuisDisparition());
    }
    IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
    IEnumerator RebondPuisDisparition()
    {
        Vector3 baseScale = transform.localScale;
        Vector3 jumpScale = baseScale * 1.3f;
        float duration = 0.2f;
        float elapsed = 0f;

        // Scale up
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(baseScale, jumpScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Scale back
        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(jumpScale, baseScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = baseScale;
        gameObject.SetActive(false);
    }


}