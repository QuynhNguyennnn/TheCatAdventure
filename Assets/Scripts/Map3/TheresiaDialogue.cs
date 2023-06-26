using System;
using UnityEngine;

public class TheresiaDialogue : MonoBehaviour
{
    UIManager manager;
    //public GameObject cat;
    //CatMove catMove;
    //WizardController wController;
    string[] conversation;
    int count = 0;
    Boolean firstTouch = true;
    Boolean isTouch;
    [SerializeField]
    private GameObject catBrownDialog;
    //public GameObject telegate;
    // Start is called before the first frame update


    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        Debug.Log(manager);
        //catMove = cat.GetComponent<CatMove>();
        //wController = FindObjectOfType<WizardController>();
        //Debug.Log(catMove);
        conversation = new string[5];
        conversation[0] = "Player (curious): Listen! I hear cries from afar. Let's find out what's happening.";
        conversation[1] = "Elric (heartbroken): These cats have no home. They need our help.";
        conversation[2] = "Summer the cat (whispering): Meow... Meow... (We don't need a reason to help.)";
        conversation[3] = "Player (determined): You're right, Summer. There's no need for a reason to help others. Let's assist these cats and defeat the pursuing monster.";
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
            Debug.Log(conversation[count]);
            manager.ShowGuild(conversation[count]);
        }
        else
        {
            manager.OffGuild();
        }

        if (count == 4)
        {
            manager.OffGuild();
            //catMove.SetPos(1);
            //wController.SetPos(0);
            firstTouch = false;
            //telegate.SetActive(true);
            gameObject.SetActive(false);
            catBrownDialog.SetActive(true);
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
