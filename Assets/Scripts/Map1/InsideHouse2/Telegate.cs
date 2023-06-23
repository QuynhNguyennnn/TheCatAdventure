using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegate : MonoBehaviour
{
    G_Telegate g_Telegate;
    public GameObject player;
    private float teleCloseTime =1f;
    private float teleCloseCounter =1f;
    private float wait = .5f;
    Animator animator;
    Boolean isClose = false;
    // Start is called before the first frame update
    void Start()
    {
        g_Telegate = FindObjectOfType<G_Telegate>();
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
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && g_Telegate.CanGo())
        {
            player.SetActive(false);
            teleCloseCounter = teleCloseTime;
            isClose = true;
        }
    }
}
