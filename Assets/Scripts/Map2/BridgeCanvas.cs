using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCanvas : MonoBehaviour
{
    private UIManager UIManager;
    [SerializeField]
    private GameObject Wizard_Bridge;
    private LeafstepController_Map2 leafStepControllerMap2;
    string[] conversation;
    [SerializeField]
    private GameObject Obstacle;
    int count = 0;
    Boolean isTouch;
    private float w_d_Time = 5 / 6f;
    private float w_d_Counter = 5 / 6f;
    private Animator animatorWizard;
    Boolean isDisappear = false;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        UIManager = FindObjectOfType<UIManager>();
        leafStepControllerMap2 = FindObjectOfType<LeafstepController_Map2>();
        animatorWizard = Wizard_Bridge.GetComponent<Animator>();
        conversation = new string[1];
        conversation[0] = "Elric(): You must have teammates to cross the \"Bridge of Friendship\"";
    }

    // Update is called once per frame
    void Update()
    {

        if (leafStepControllerMap2.hasKey)
        {
            Wizard_Bridge.SetActive(false);
            Obstacle.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isTouch)
            {
                count = 0;
                isTouch = false;
            }

            if (isTouch)
            {
                UIManager.ShowGuild(conversation[count]);
            }
            else
            {
                UIManager.OffGuild();
            }
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
            isTouch = false;
            UIManager.OffGuild();
        }
    }
    public void toggleTouch()
    {
        isTouch = !isTouch;
        count = 5;
    }
}
