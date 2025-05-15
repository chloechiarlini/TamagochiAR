using UnityEngine;
using UnityEngine.SceneManagement;
public class CustomizationMenu : MonoBehaviour
    {
        public void SetColorRed() => SaveColor(Color.red);
        public void SetColorBlue() => SaveColor(Color.blue);
        public void SetColorYellow() => SaveColor(Color.yellow);

        void SaveColor(Color color)
        {
            PlayerPrefs.SetFloat("MametchiColorR", color.r);
            PlayerPrefs.SetFloat("MametchiColorG", color.g);
            PlayerPrefs.SetFloat("MametchiColorB", color.b);
        }

        public void ToggleHat(bool hasHat)
        {
            PlayerPrefs.SetInt("MametchiHat", hasHat ? 1 : 0);
        }

        public void SetSound(int index)
        {
            PlayerPrefs.SetInt("MametchiSound", index);
        }

        public void ValidateAndReturn()
        {
            SceneManager.LoadScene("scene-accueil");
        }
    }

