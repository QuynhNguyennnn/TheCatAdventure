using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoIn1"))
        {
            PlayerPrefs.SetFloat("PlayerPositionX", 0.33f);
            PlayerPrefs.SetFloat("PlayerPositionY", -4.15f);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            SceneManager.LoadScene("InsideHouse1");
        } else if (collision.CompareTag("GoIn2"))
        {
            PlayerPrefs.SetFloat("PlayerPositionX", 0.63f);
            PlayerPrefs.SetFloat("PlayerPositionY", -4.9f);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            SceneManager.LoadScene("InsideHouse2");
        }
    }
}
