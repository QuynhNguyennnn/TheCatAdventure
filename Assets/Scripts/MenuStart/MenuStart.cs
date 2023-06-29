using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetFloat("PlayerPositionX", -2.81f);
        PlayerPrefs.SetFloat("PlayerPositionY", 1.6f);
        PlayerPrefs.SetFloat("PlayerPositionZ", 0);

        SceneManager.LoadScene("InsideHouse1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
