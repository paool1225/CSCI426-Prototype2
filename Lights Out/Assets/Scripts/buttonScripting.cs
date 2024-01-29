using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonScripting : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMain()
    {
        SceneManager.LoadSceneAsync("Menu");

    }
}
