using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleMap4_2 : MonoBehaviour
{
    private UIManager UIManager;
    private HealthManager healthManager;
    private bool isTouch = false;
    private int count = 0;
    private int maxTurn = 10;
    private string[] riddleMap4_2;
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
        riddleMap4_2 = new string[2];
        riddleMap4_2[0] = "Press H for A anwser, J for B, K for C, L for D";
        riddleMap4_2[1] = "I'm a feline with stripes so bold,\nIn the jungle, I'm strong and bold.\r\nWhat am I?\n" +
            "A) Lion         " + "B) Tiger\n" 
            +
            "C) Cheetah      " + "D) Leopard";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == riddleMap4_2.Length)
            {
                count = 0;
                isTouch = false;
            }
        }
        if (!isCorrect) // countTurn < maxTurn
        {
            UIManager.ShowGuild(riddleMap4_2[1]);
            GetAnwser();
        }
        if (isTouch && !isCorrect)
        {
            UIManager.ShowGuild(riddleMap4_2[count]);
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
            healthManager.currentHealth += 5;
            if (healthManager.currentHealth > 50)
            {
                healthManager.currentHealth = 50;
            }
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
        Debug.Log("cham riddle2");

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
