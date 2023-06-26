using System;
using UnityEngine;

public class NecklaceDialogue : MonoBehaviour
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
    private GameObject magicCatDialog;
    [SerializeField]
    private GameObject catNeck;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        manager = FindObjectOfType<UIManager>();
        //catMove = cat.GetComponent<CatMove>();
        //wController = FindObjectOfType<WizardController>();
        //Debug.Log(catMove);
        conversation = new string[3];
        conversation[0] = "Player (curious): This is the third necklace.";
        conversation[1] = "Theresia: You need to meet the Magic Cat to see the next Task.";
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

        if (count == 2)
        {
            catNeck.SetActive(false);
            magicCatDialog.SetActive(true);
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
