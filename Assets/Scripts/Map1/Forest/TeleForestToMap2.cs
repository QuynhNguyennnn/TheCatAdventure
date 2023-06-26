using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TeleForestToMap2 : MonoBehaviour
{
    bool isStart = false;
    [SerializeField]
    private GameObject tele;
    Animator t_animator;

    UIManager manager;
    string[] conversation;
    int count = 0;
    int countDo = 0;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject cat;

    [SerializeField]
    private GameObject wizard;
    Animator w_animator;

    bool isOpen = false;
    bool isWizardD = false;

    private float teleOpenTime = 4 / 3f;
    private float teleOpenCounter = 4 / 3f;

    private float w_d_Time = 5 / 6f;
    private float w_d_Counter = 5 / 6f;
    // Start is called before the first frame update
    void Start()
    {
        conversation = new string[3];
        conversation[0] = "Elric: I will open the gate!";
        conversation[1] = "Meow! (I go!)";
        conversation[2] = "Elric: I go too!";

        isStart = true;
        manager = FindObjectOfType<UIManager>();

        w_animator = wizard.GetComponent<Animator>();
        t_animator = tele.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart && count < 3)
        {
            manager.ShowGuild(conversation[count]);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isStart)
        {
            count++;
        }

        if (countDo == 0 && count == 0)
        {
            tele.SetActive(true);
            teleOpenCounter = teleOpenTime;
            isOpen = true;
            countDo++;
        }

        if (countDo == 1 && count == 1)
        {
            cat.GetComponent<CatMoveForest>().SetPos(1);
            countDo++;
        }

        if ( Vector2.Distance(cat.transform.position, cat.GetComponent<CatMoveForest>().GetPos(1).position) == 0)
        {
            cat.GetComponent<Renderer>().sortingOrder = -1;
            
        }

        if (countDo == 2 && count == 2)
        {
            w_d_Counter = w_d_Time;
            w_animator.SetBool("isDisappear", true);
            isWizardD = true;
            countDo++;
        }

        if (isWizardD)
        {
            Debug.Log(w_d_Counter);
            w_d_Counter -= Time.deltaTime;
            if( w_d_Counter <= 0)
            {
                Destroy(wizard);
                isWizardD = false;
            }
        }
        if (count >= 3 && isWizardD == false)
        {
            manager.OffGuild();
            player.GetComponent<PlayerController>().ToggleMove();
            Destroy(gameObject);
        }

        if (isOpen) {
            teleOpenCounter -= Time.deltaTime;
            if (teleOpenCounter <= 0)
            {
                isOpen = false;
                t_animator.SetBool("IsIdle", true);
            }
        }
    }
}
