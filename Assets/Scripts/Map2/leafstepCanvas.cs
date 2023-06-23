using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafstepCanvas : MonoBehaviour
{
    private UIManager UIManager;
    private LeafstepController_Map2 leafStepControllerMap2;
    [SerializeField]
    private GameObject LeafstepArea;
    [SerializeField]
    private GameObject BridgeCanvas;
    [SerializeField]
    private GameObject Wizard_Bridge;
    [SerializeField]
    private GameObject Obstacle;
    string[] conversation;
    int count = 0;
    Boolean firstTouch = true;
    Boolean isTouch;
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        UIManager = FindObjectOfType<UIManager>();
        leafStepControllerMap2 = FindObjectOfType<LeafstepController_Map2>();
        conversation = new string[50];
        conversation[0] = "Leafstep(probe): Hey hero, didn't Elric tell you to come find me?";
        conversation[1] = "Player(surprised): You know Elric? So are you the comrade that will accompany me that he mentioned?";
        conversation[2] = "Leafstep(): I'm Leafstep, I've been in this forest for a long time, waiting for my teammates to cross the \"Bridge of Friendship\", defeat \"SkeleKing\" to find the fragment of the legendary cat collar.";
        conversation[3] = "Player(): Wait! What is \"Bridge of Friendship\" and \"SkeleKing\"?";
        conversation[4] = "Leafstep(): \"Bridge of Friendship\" is an ancient bridge that you cannot cross alone, you can only cross it when you have teammates beside you.";
        conversation[5] = "Player(): Oh! What about \"SkeleKing\"?";
        conversation[6] = "Leafstep(): \"SkeleKing\" is an ancient monster that is guarding the holy place, only when you defeat it can you find the fragment of the necklace.";
        conversation[7] = "player(): So it is. So, Leafstep, do you want to come with me on my way to collect the broken pieces of the cat necklace?";
        conversation[8] = "Leafstep(): Of course boy, I will accompany you on the next journey.";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouch)
        {
            count++;
            //if (count == 5)
            //{
            //    isTouch = false;
            //}
        }

        if (isTouch && leafStepControllerMap2.hasKey == false)
        {
            gameObject.SetActive(true);
            UIManager.ShowGuild(conversation[count]);
        }
        else
        {
            UIManager.OffGuild();
        }

        if (count == 9)
        {
            UIManager.OffGuild();
            firstTouch = false;
            leafStepControllerMap2.hasKey = true;
            LeafstepArea.SetActive(false);
            Wizard_Bridge.SetActive(false);
            Obstacle.SetActive(false);
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
            UIManager.OffGuild();
        }
    }
    public void toggleTouch()
    {
        isTouch = !isTouch;
        count = 5;
    }
}
