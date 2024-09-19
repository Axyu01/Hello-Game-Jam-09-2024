using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("TEST_Sosivo");
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

}
