using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodbyeCanvas : MonoBehaviour
{
    private UIManager manager;
    string[] conversation;
    int count = 0;
    Boolean firstTouch = true;
    Boolean isTouch;

    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        Debug.Log("Start scene");
        conversation = new string[4];
        conversation[0] = "Congratulations, hero! You have passed the enchanted forest!";
        conversation[1] = "But don't forget, we still have to keep fighting to protect what's precious to us.";
        conversation[2] = "Let's continue the journey together and face the next challenges.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouch)
        {
            count++;
            //if (count == 5)
            //{
            //    cat.SetActive(true);
            //    catMove.SetPos(0);
            //    isTouch = false;
            //}
        }

        if (isTouch && firstTouch)
        {
            manager.ShowGuild(conversation[count]);
        }
        else
        {
            manager.OffGuild();
        }

        if (count == 3)
        {
            manager.OffGuild();
            //catMove.SetPos(1);
            //wController.SetPos(0);
            firstTouch = false;
            //telegate.SetActive(true);
            gameObject.SetActive(false);
            Destroy(gameObject);
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

    public void toggleTouch()
    {
        isTouch = !isTouch;
        count = 5;
    }
}
