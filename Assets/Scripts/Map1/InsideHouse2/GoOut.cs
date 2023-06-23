using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoOut : MonoBehaviour
{

    string sceneName = "Map1";
    private Rigidbody2D my_rb;
    // Start is called before the first frame update
    void Start()
    {
        my_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoOut1"))
        {
            PlayerPrefs.SetFloat("PlayerPositionX", -7.13f);
            PlayerPrefs.SetFloat("PlayerPositionY", 2f);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            SceneManager.LoadScene(sceneName);
        }
        else if (collision.CompareTag("GoOut2"))
        {
            PlayerPrefs.SetFloat("PlayerPositionX", -5.44f);
            PlayerPrefs.SetFloat("PlayerPositionY", 47.7f);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            SceneManager.LoadScene(sceneName);
        }
    }
}
