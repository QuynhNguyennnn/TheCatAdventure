using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleMap4_1: MonoBehaviour
{
    private UIManager UIManager;
    private HealthManager healthManager;
    private bool isTouch = false;
    private int count = 0;
    private int maxTurn = 10;
    private string[] riddleMap4_1;
    private int countTurn = 0;
    private int damageToGive = 2;
    private bool isCorrect = false;


    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        healthManager = FindObjectOfType<HealthManager>();
        isTouch = false;
        count = 0;
        countTurn = 0;
        riddleMap4_1 = new string[2];
        riddleMap4_1[0] = "Press H for A anwser, J for B, K for C, L for D";
        riddleMap4_1[1] = "If it takes 3 cats 3 minutes to catch 3 mice,\nHow long would it take 100 cats to catch 100 mice?\n" +
            "A) 1 minutes       " +" B) 3 minute\n"
             +
            "C) 30 minutes      " + "D) 100 minutes";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == riddleMap4_1.Length)
            {
                count = 0;
                isTouch = false;
            }
        }
        if (!isCorrect) // countTurn < maxTurn
        {
            UIManager.ShowGuild(riddleMap4_1[1]);
            GetAnwser();
        }
        if (isTouch && !isCorrect)
        {
            UIManager.ShowGuild(riddleMap4_1[count]);
        }
        else
        {
            UIManager.OffGuild();
        }
    }

    private void GetAnwser()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isCorrect = false;
            countTurn++;
            healthManager.HurtPlayer(damageToGive);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            isCorrect = true;
            healthManager.currentHealth = 50;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            isCorrect = false;
            countTurn++;
            healthManager.HurtPlayer(damageToGive);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            isCorrect = false;
            countTurn++;
            healthManager.HurtPlayer(damageToGive);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
        gameObject.SetActive(true);
        Debug.Log("cham riddle1");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isCorrect)
            {
                isTouch = false;
                UIManager.OffGuild();
            }
            else
            {
                Update();
            }

        }

    }
}
