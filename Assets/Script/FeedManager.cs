using UnityEngine;
using System.Collections;

public class FeedManager : MonoBehaviour
{
    public GameObject fraisePrefab;
    public SpawnArcGizmo arcConfig;
    public Transform fraisesContainer;
    public GameObject MerciBubble;
    public AudioClip popSound;

    private int fraisesMangees = 0;
    private int totalFraises = 0;
    private Animator merciAnimator;

    private void Start()
    {
        if (MerciBubble != null)
        {
            MerciBubble.SetActive(false); // cacher au démarrage
            merciAnimator = MerciBubble.GetComponent<Animator>();

            if (merciAnimator != null)
                merciAnimator.SetBool("ShowMerci", false);
        }

        Debug.Log("✅ Animator trouvé : " + (merciAnimator != null));
    }

    public void SpawnFraises()
    {
        float arcRadius = arcConfig.arcRadius;
        float heightOffset = arcConfig.heightOffset;
        int numberOfFraises = Mathf.Max(arcConfig.numberOfPoints, 1);
        float totalArcAngle = arcConfig.totalArcAngle;

        Quaternion rotation = arcConfig.transform.rotation;
        Vector3 center = arcConfig.transform.position + Vector3.up * heightOffset;

        for (int i = 0; i < numberOfFraises; i++)
        {
            float angleDeg = (numberOfFraises == 1) ? 0f :
                -totalArcAngle / 2f + (totalArcAngle / (numberOfFraises - 1)) * i;

            float angleRad = angleDeg * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Sin(angleRad) * arcRadius,
                0f,
                Mathf.Cos(angleRad) * arcRadius
            );

            Vector3 position = center + (rotation * offset);

            GameObject f = Instantiate(fraisePrefab, position, Quaternion.identity, fraisesContainer);
            f.transform.localEulerAngles = new Vector3(-9.155f, -16.372f, -97f);
            float randomScale = Random.Range(0.60f, 0.70f);
            f.transform.localScale = Vector3.zero;

            Fraise fScript = f.GetComponent<Fraise>();
            fScript.feedManager = this;

            StartCoroutine(AnimatePop(f.transform, randomScale));
            PlayPopSound(position);
        }

        totalFraises += numberOfFraises;
    }

    IEnumerator AnimatePop(Transform target, float targetSize)
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Vector3 targetScale = Vector3.one * targetSize;

        while (elapsed < duration)
        {
            target.localScale = Vector3.Lerp(Vector3.zero, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.localScale = targetScale;
    }

    public void NotifyStrawberryEaten()
    {
        fraisesMangees++;
        if (fraisesMangees >= totalFraises)
            ShowMerci();
    }

    void ShowMerci()
    {
        Debug.Log("✅ ShowMerci appelé !");

        if (MerciBubble != null)
        {
            MerciBubble.SetActive(true);

            if (merciAnimator != null)
                merciAnimator.SetBool("ShowMerci", true);

            Invoke(nameof(HideMerci), 4f);
        }
    }

    void HideMerci()
    {
        if (merciAnimator != null)
            merciAnimator.SetBool("ShowMerci", false);

        if (MerciBubble != null)
            MerciBubble.SetActive(false);
    }

    void PlayPopSound(Vector3 pos)
    {
        if (popSound != null)
            AudioSource.PlayClipAtPoint(popSound, pos, 1f);
        else
            Debug.LogWarning("⚠️ FeedManager : Aucun popSound assigné !");
    }
}