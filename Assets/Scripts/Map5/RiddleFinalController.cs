using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleFinalController : MonoBehaviour
{
    private UIManager UIManager;
    private HealthManager healthManager;
    private bool isTouch = false;
    private int count = 0;
    private int maxTurn = 4;
    private string[] riddleThird;
    private int countTurn = 0;
    private int damageToGive = 2;
    public bool isCorrect = false;
    [SerializeField]
    private GameObject guildNoti;
    [SerializeField]
    private GameObject ridderFirst;
    [SerializeField]
    private GameObject riddleSecond;
    [SerializeField]
    private GameObject Necklace;
    [SerializeField]
    private GameObject Congratulation;
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        healthManager = FindObjectOfType<HealthManager>();
        isTouch = false;
        guildNoti.SetActive(false);
        ridderFirst.SetActive(false);
        riddleSecond.SetActive(false);
        Congratulation.SetActive(false);
        count = 0;
        countTurn = 0;
        riddleThird = new string[2];
        riddleThird[0] = "Press H for A anwser, J for B, K for C, L for D";
        riddleThird[1] = "What do you get when you cross a black cat and a lemon\n" +
            " A. A black lemon           B. A lemonade\n C. A citrus cat            D. A sour puss";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == riddleThird.Length)
            {
                count = 0;
                isTouch = false;
            }
        }
        if (!isCorrect) //countTurn < maxTurn && 
        {
            UIManager.ShowGuild(riddleThird[count]);
            GetAnwser();
        }
        if (isTouch && !isCorrect)
        {
            UIManager.ShowGuild(riddleThird[count]);
        }
        else
        {
            UIManager.OffGuild();
        }
    }

    private void GetAnwser()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isCorrect = true;
            healthManager.currentHealth += 5;
            if (healthManager.currentHealth > 50)
            {
                healthManager.currentHealth = 50;
            }

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            isCorrect = false;
            countTurn++;
            healthManager.HurtPlayer(damageToGive);

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            isCorrect = false;
            countTurn++;
            healthManager.HurtPlayer(damageToGive);

        }
        if (Input.GetKeyDown(KeyCode.H))
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
        Debug.Log("cham riddle 3");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isCorrect)
            {
                isTouch = false;
                UIManager.OffGuild();
                Necklace.SetActive(true);
                Congratulation.SetActive(true);
            } else
            {
                Update();
            }
            
            //gameObject.SetActive(false);
        }

    }
}
