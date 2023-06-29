using System;
using UnityEngine;

public class TheresiaDialogue : MonoBehaviour
{
    UIManager manager;
    //public GameObject cat;
    //CatMove catMove;
    //WizardController wController;
    string[] conversation;

    [SerializeField]
    private GameObject catRed;
    int count = 0;
    Boolean firstTouch = true;
    Boolean isTouch;
    [SerializeField]
    private GameObject catBrownDialog;
    [SerializeField]
    private GameObject player;
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
        conversation = new string[2];
        conversation[0] = "Theresia: Meow! (Hero please help us!)";
        conversation[1] = "Player (determined): Okay I'll help everyone!";
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

        if (isTouch && firstTouch && count <2)
        {
            manager.ShowGuild(conversation[count]);
        }
        else
        {
            manager.OffGuild();
        }

        if (count == 2)
        {
            manager.OffGuild();
            firstTouch = false;
            gameObject.SetActive(false);
            player.GetComponent<PlayerController>().ToggleMove();
            catBrownDialog.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
        player.GetComponent<PlayerController>().ToggleMove();
        catRed.SetActive(true);
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
