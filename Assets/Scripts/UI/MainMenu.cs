using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Image FadePanel;
    public float FadeDuration;

    private void Start()
    {
        FadePanel.color = new Color(0, 0, 0, 0);
    }

    public void StartGame()
    {

        GameObject backgroundMusic = GameObject.Find("BackgroundMusic");
        if (backgroundMusic != null)
        {
            AudioSource audioSource = backgroundMusic.GetComponent<AudioSource>();
            if (audioSource != null) {
                Destroy(backgroundMusic);
            }
        }
        StartCoroutine(FadeOut());
        //SceneManager.LoadScene("TEST_Sosivo");
    }

    public void Instruction()
    {
        
    }

    public void Credits()
    {
        
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color panelColor = FadePanel.color;

        while (elapsedTime < FadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / FadeDuration);
            FadePanel.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null;
        }

        SceneManager.LoadScene("TEST_Sosivo");
    }

}
