using UnityEngine;

public class MametchiInteraction : MonoBehaviour
{
    private Vector3 startPosition;
    private AudioSource audioSource;
    private bool isJumping = false;
    private Camera arCamera;
    private bool isInitialized = false;
    

    void Start()
    {
        InitializeComponents();
    }

    void InitializeComponents()
    {
        if (isInitialized) return;

        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();

        // Vérification des composants
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource manquant sur Mametchi !");
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Vérification du collider
        if (GetComponent<Collider>() == null)
        {
            Debug.LogWarning("Collider manquant sur Mametchi !");
            gameObject.AddComponent<BoxCollider>();
        }

        // Recherche de la caméra AR avec un délai pour laisser le temps à Vuforia de s'initialiser
        StartCoroutine(FindARCamera());
    }

    System.Collections.IEnumerator FindARCamera()
    {
        int attempts = 0;
        while (arCamera == null && attempts < 10)
        {
            arCamera = GameObject.FindGameObjectWithTag("ARCamera")?.GetComponent<Camera>();
            if (arCamera == null)
            {
                Debug.Log("Tentative de recherche de l'ARCamera...");
                yield return new WaitForSeconds(0.5f);
                attempts++;
            }
        }

        if (arCamera == null)
        {
            Debug.LogError("ARCamera non trouvée après plusieurs tentatives !");
        }
        else
        {
            Debug.Log("ARCamera trouvée avec succès !");
            isInitialized = true;
        }
    }

    void OnDestroy()
    {
        // Nettoyage des coroutines
        StopAllCoroutines();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clic détecté");
        }
        if (!isInitialized) return;

        if (Input.GetMouseButtonDown(0) && arCamera != null)
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("Tentative de clic détectée");

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Objet touché : {hit.transform.name}");
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 2f); // ← Ligne rouge visible dans la scène


                if (hit.transform == transform && !isJumping)
                {
                    Debug.Log("Mametchi cliqué → saute !");
                    StartCoroutine(Jump());

                    if (audioSource != null)
                        audioSource.Play();
                }
            }
            else
            {
                Debug.Log("Aucun objet touché par le raycast");
            }
        }
    }

    System.Collections.IEnumerator Jump()
    {
        isJumping = true;
        Debug.Log("Début du saut stylé");

        float jumpHeight = 2f;
        float jumpDuration = 0.6f;
        float elapsedTime = 0f;

        Vector3 originalPos = transform.position;

        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / jumpDuration;

            // Mouvement vers le haut et retour, comme un arc
            float height = Mathf.Sin(Mathf.PI * t) * jumpHeight;
            transform.position = originalPos + new Vector3(0, height, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;
        isJumping = false;
        Debug.Log("Fin du saut stylé");
    }
}