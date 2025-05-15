using UnityEngine;
using UnityEngine.UI;

public class DayNightManager : MonoBehaviour
{
    public Light directionalLight;            // Ta lumière Directional Light
    public Material daySkybox;                // Skybox pour le jour
    public Material nightSkybox;              // Skybox pour la nuit

    public Sprite soleilIcon;                 // Icône du soleil
    public Sprite luneIcon;                   // Icône de la lune
    public Image toggleButtonImage;           // Le composant Image de ton bouton

    private bool isDay = true;

    void Start()
    {
        ApplyDayNight(); // Appliquer l'état initial
    }

    public void ToggleDayNight()
    {
        isDay = !isDay;
        ApplyDayNight();
    }

    private void ApplyDayNight()
    {
        if (isDay)
        {
            directionalLight.color = Color.white;
            RenderSettings.skybox = daySkybox;
            toggleButtonImage.sprite = luneIcon;
        }
        else
        {
            directionalLight.color = new Color(0.2f, 0.2f, 0.4f); // teinte nuit
            RenderSettings.skybox = nightSkybox;
            toggleButtonImage.sprite = soleilIcon;
        }
    }
}