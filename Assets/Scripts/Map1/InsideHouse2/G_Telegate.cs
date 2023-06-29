using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class G_Telegate : MonoBehaviour
{
    UIManager manager;
    public GameObject telegate;
    public GameObject wizard;
    CatMove catMove;
    Animator a_wizard;
    Animator a_tele;
    string[] conversation;
    Boolean firstTouch = true;
    int count = 0;
    Boolean isTouch;
    public GameObject limitRange;
    
    Boolean canDo = false;
    private int countDo = 0;
    private float teleOpenTime = 4/3f;
    private float teleOpenCounter = 4/3f;

    private float w_d_Time = 5/6f;
    private float w_d_Counter = 5/6f;

    // Start is called before the first frame update
    void Start()
    {
        catMove = FindObjectOfType<CatMove>();
        a_wizard = wizard.GetComponent<Animator>();
        a_tele = telegate.GetComponent<Animator>();
        manager = FindObjectOfType<UIManager>();
        conversation = new string[3];
        conversation[0] = "Elric: Now I will open the portal.";
        conversation[1] = "Meow! (I go first!)";
        conversation[2] = "Elric: I'm going too";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && firstTouch && canDo)
        {
            count++;
        }

        if (count == 3 && firstTouch)
        {
            a_wizard.SetBool("isDisappear", true);
            w_d_Counter = w_d_Time;
            countDo++;
            canDo = false;
            manager.OffGuild();
            firstTouch = false;
        } else if (count == 1)
        {
            catMove.SetPos(2);
        } else if(count == 3) {
            count = 3;
        }

        if (isTouch && firstTouch)
        {
            manager.ShowGuild(conversation[count]);
        }
        else
        {
            manager.OffGuild();
        }

        if (!canDo)
        {
            if (countDo == 1)
            {
                teleOpenCounter -= Time.deltaTime;
                if (teleOpenCounter <= 0)
                {
                    a_tele.SetBool("IsIdle", true);
                    canDo = true;
                }
            } else if(countDo == 2)
            {
                w_d_Counter -= Time.deltaTime;
                if(w_d_Counter <= 0)
                {
                    wizard.SetActive(false);
                    canDo = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
        telegate.SetActive(true);
        limitRange.SetActive(true);
        canDo = false;
        countDo = 1;
        teleOpenCounter = teleOpenTime;
    }

    public bool CanGo()
    {
        if (canDo && count == 3)
            return true;
        else 
            return false;
    }
}
