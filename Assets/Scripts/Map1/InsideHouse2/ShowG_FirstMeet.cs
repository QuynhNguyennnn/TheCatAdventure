using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowG_FirstMeet : MonoBehaviour
{
    UIManager manager;
    public GameObject cat;
    CatMove catMove;
    WizardController wController;
    string[] conversation;
    int count = 0;
    Boolean firstTouch = true;
    Boolean isTouch;
    [SerializeField]
    private GameObject player;
    public GameObject telegate;
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        catMove = cat.GetComponent<CatMove>();
        wController = FindObjectOfType<WizardController>();
        Debug.Log(catMove);
        conversation = new string[7];
        conversation[0] = "Elric (joy): Welcome to the home of the Hero, you have come at the right time. Summer the cat and the power of the \"cat necklace\" are waiting for us.";
        conversation[1] = "Player (interested): Cat necklace? I heard about it through legend. But no one knows where it is.";
        conversation[2] = "Elric (contemplation): Yes, sir. The Summer's necklace has been split into many small pieces and hidden in the mysterious forests throughout this magical world. However, one piece was found recently in the nearby forest.";
        conversation[3] = "Player (curious): So where are we going to start the journey?";
        conversation[4] = "Elric (nods): That's right. Summer the cat will be the one to guide us to that piece of rock. Get everything ready and let's start this adventurous adventure.";
        conversation[5] = "Summer: Meow! Meow! (Welcome hero! Follow me!)";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouch) {
            count++;
            if(count == 5) {
                cat.SetActive(true);
                catMove.SetPos(0);
                isTouch = false;
            }
        }

        if (isTouch && firstTouch)
        {
            manager.ShowGuild(conversation[count]);
        }
        else
        {
            manager.OffGuild();
        }

        if (count == 6)
        {
            manager.OffGuild();
            catMove.SetPos(1);
            wController.SetPos(0);
            firstTouch = false;
            telegate.SetActive(true);
            player.GetComponent<PlayerController>().ToggleMove();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
        player.GetComponent<PlayerController>().ToggleMove();
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

    public void toggleTouch()
    {
        isTouch = !isTouch;
        count = 5;
    }
}
