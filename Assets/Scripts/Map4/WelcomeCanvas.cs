using System;
using UnityEngine;

public class WelcomeCanvas : MonoBehaviour
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
        conversation[0] = "Welcome to the Enchanted Forest.";
        conversation[1] = "This is where your memories and past are kept.";
        conversation[2] = "Let's fight and overcome them to move forward.";
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
