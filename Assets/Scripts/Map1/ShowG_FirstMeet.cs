using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowG_FirstMeet : MonoBehaviour
{
    UIManager manager;
    string[] conversation;
    int count = 0;
    Boolean isTouch;
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        conversation = new string[7];
        conversation[0] = "Elric (joy): Welcome to the home of the Hero, you have come at the right time. Summer the cat and the power of the \"cat collar\" are waiting for us.";
        conversation[1] = "Player (interested): Cat collar? I heard about it through legend. But no one knows where it is.";
        conversation[2] = "Elric (contemplation): Yes, sir. The cat collar has been split into many small pieces and hidden in the mysterious forests throughout this magical world.";
        conversation[3] = "However, one piece was found recently in the nearby forest.";
        conversation[4] = "Player (curious): So where are we going to start the journey?";
        conversation[5] = "Elric (nods): That's right. Summer the cat will be the one to guide us to that piece of rock.";
        conversation[6] = "Get everything ready and let's start this adventurous adventure.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            count++;
            if(count == conversation.Length)
            {
                count = 0;
                isTouch = false;
            }
        }

        if (isTouch)
        {
            manager.ShowGuild(conversation[count]);
        }
        else
        {
            manager.OffGuild();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            count = 0;
            isTouch = false;
            manager.OffGuild();
        }
    }
}
