using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startCanvas : MonoBehaviour
{
    private UIManager UIManager;
    [SerializeField]
    private GameObject Wizard;
    [SerializeField]
    private GameObject leafstepCanvas;
    string[] conversation;
    int count = 0;
    Boolean isTouch;
    private float w_d_Time = 5/6f;
    private float w_d_Counter = 5/6f;
    private Animator animatorWizard;
    Boolean isDisappear = false;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        UIManager = FindObjectOfType<UIManager>();
        animatorWizard = Wizard.GetComponent<Animator>();
        conversation = new string[7];
        conversation[0] = "Elric(joy): Well done lad, you passed the first challenge and found 1 of the 5 shards of the cat necklace!";
        conversation[1] = "Player: As you say, this journey is certainly full of new and dangerous experiences. But we can only rise to the challenge and discover the beauty of this magical world with courage and determination.";
        conversation[2] = "Elric(severe): We have overcome the initial hurdles. But there's not much time left to waste. First, to overcome this mysterious forest, he must have a comrade who will accompany him to overcome difficulties and challenges on the upcoming journey.";
        conversation[3] = "Player(interested): great! Where can I find that person?";
        conversation[4] = "Elric(blandly): go north towards the cover one by one you will find that person."; 
        conversation[5] = "Elric: I go first!";
        conversation[6] = "Meow! See you again hero!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouch)
        {
            count++;
            if (count == 5)
            {
                isTouch = false;
                UIManager.OffGuild();
                animatorWizard.SetBool("isDisappear", true);
                w_d_Counter = w_d_Time;
                isDisappear = true;
            }
        }

        if (isTouch)
        {
            UIManager.ShowGuild(conversation[count]);
        }
        else
        {
            UIManager.OffGuild();
        }

        if (isDisappear)
        {
            w_d_Counter -= Time.deltaTime;
            if (w_d_Counter <= 0)
            {
                Wizard.SetActive(false);
                //leafstepCanvas.SetActive(true);
                Destroy(gameObject);
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
            UIManager.OffGuild();
        }
    }
    public void toggleTouch()
    {
        isTouch = !isTouch;
        count = 5;
    }
}
