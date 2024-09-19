using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene("Instructions");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
