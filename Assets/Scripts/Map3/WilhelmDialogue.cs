using System;
using UnityEngine;

public class WilhelmDialogue : MonoBehaviour
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
    private GameObject necklaceDialog;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        //catMove = cat.GetComponent<CatMove>();
        //wController = FindObjectOfType<WizardController>();
        //Debug.Log(catMove);
        conversation = new string[5];
        conversation[0] = "Wilhelm & Theresia (joyful): Meow! Meow! (Thank you for helping us!)";
        conversation[1] = "Elric (curious): This temple might hold the fragment we're looking for.";
        conversation[2] = "Elric (excited): We've found the third fragment! We're getting closer to our goal.";
        conversation[3] = "Wilhelm & Theresia (grateful): Meow! Meow! (You've helped us, and we're very grateful.)";
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

        if (count == 4)
        {
            necklaceDialog.SetActive(true);
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
