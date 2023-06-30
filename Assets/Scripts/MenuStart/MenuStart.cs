using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [SerializeField]
    private GameObject newGame;
    [SerializeField]
    private GameObject loadGame;
    float i;
    private void Start()
    {

        Debug.Log(PlayerPrefs.GetFloat("Level"));
        if (PlayerPrefs.GetFloat("Level") >= 1 && PlayerPrefs.GetFloat("Level") <= 5)
        {
            loadGame.SetActive(true);
            i = PlayerPrefs.GetFloat("Level");
        }
        else if (PlayerPrefs.GetString("Level") == "")
        {
            newGame.SetActive(true);   
        }
    }

    public void PlayGame()
    {
        PlayerPrefs.SetFloat("PlayerPositionX", -2.81f);
        PlayerPrefs.SetFloat("PlayerPositionY", 1.6f);
        PlayerPrefs.SetFloat("PlayerPositionZ", 0);

        PlayerPrefs.SetString("Type", "");
        PlayerPrefs.SetFloat("Level", 1);
        SceneManager.LoadScene("InsideHouse1");
    }

    public void LoadGame()
    {
        switch (i)
        {
            case 1:
                PlayerPrefs.SetFloat("PlayerPositionX", -2.81f);
                PlayerPrefs.SetFloat("PlayerPositionY", 1.6f);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                SceneManager.LoadScene("InsideHouse1");
                break;

            case 1.5f:
                PlayerPrefs.SetFloat("PlayerPositionX", -27.9f);
                PlayerPrefs.SetFloat("PlayerPositionY", 10.6f);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                SceneManager.LoadScene("Forest");
                break;

            case 2:
                PlayerPrefs.SetFloat("PlayerPositionX", -20.6f);
                PlayerPrefs.SetFloat("PlayerPositionY", 14.4f);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                SceneManager.LoadScene("Map2");
                break;

            case 3:
                PlayerPrefs.SetFloat("PlayerPositionX", -15.01606f);
                PlayerPrefs.SetFloat("PlayerPositionY", 10.35958f);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                SceneManager.LoadScene("Map3");
                break;

            case 4:
                PlayerPrefs.SetFloat("PlayerPositionX", -54.96f);
                PlayerPrefs.SetFloat("PlayerPositionY", -103.58f);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                SceneManager.LoadScene("Map4");
                break;

            case 5:
                PlayerPrefs.SetFloat("PlayerPositionX", -111.16f);
                PlayerPrefs.SetFloat("PlayerPositionY", -4.93f);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                SceneManager.LoadScene("Map5");
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
