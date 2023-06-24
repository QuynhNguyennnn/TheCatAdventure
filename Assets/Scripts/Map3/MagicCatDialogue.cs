using System;
using UnityEngine;

public class MagicCatDialogue : MonoBehaviour
{
    UIManager manager;
    //public GameObject cat;
    //CatMove catMove;
    //WizardController wController;
    string[] conversation;
    int count = 0;
    Boolean firstTouch = true;
    Boolean isTouch;
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        //catMove = cat.GetComponent<CatMove>();
        //wController = FindObjectOfType<WizardController>();
        //Debug.Log(catMove);
        conversation = new string[5];
        conversation[0] = "Magic Cat: Congratulation, you have the third cat necklace!";
        conversation[1] = "Player: Theresia want me to meet you.";
        conversation[2] = "Magic Cat: Meow... Meow... I see I see!";
        conversation[3] = "Magic Cat: If you want to going foward to the next travel, you need to killing the ghost. The ghost who is the devil in the forest which stranger magic";
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
