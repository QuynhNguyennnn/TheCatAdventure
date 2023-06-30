using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleGateForest_Map2 : MonoBehaviour
{
    public GameObject player;
    private float teleCloseTime = 1f;
    private float teleCloseCounter = 1f;
    private float wait = .5f;
    Animator animator;
    Boolean isClose = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose)
        {
            wait -= Time.deltaTime;
            if (wait <= 0)
            {
                animator.SetBool("IsClose", true);
                teleCloseCounter -= Time.deltaTime;
                if (teleCloseCounter <= 0)
                {
                    PlayerPrefs.SetFloat("PlayerPositionX", -20.6f);
                    PlayerPrefs.SetFloat("PlayerPositionY", 14.4f);
                    PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                    PlayerPrefs.SetFloat("Level", 2f);

                    SceneManager.LoadScene("Map2");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.SetActive(false);
            teleCloseCounter = teleCloseTime;
            isClose = true;
        }
    }
}
