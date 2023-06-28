using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleFirstController : MonoBehaviour
{
    private UIManager UIManager;
    private HealthManager healthManager;
    private bool isTouch = false;
    private int count = 0;
    private int maxTurn = 10;
    private string[] riddleFirst;
    private int countTurn = 0;
    private int damageToGive = 2;
    private bool isCorrect = false;
    [SerializeField]
    private GameObject riddleSecond;
    [SerializeField]
    private GameObject player;


    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        healthManager = FindObjectOfType<HealthManager>();
        isTouch = false;
        count = 0;
        countTurn = 0;
        riddleFirst = new string[2];
        riddleFirst[0] = "Press H for A anwser, J for B, K for C, L for D";
        riddleFirst[1] = "Why was the big cat thrown out of the card game?\n" +
            "A. He was a cheetah     " +
            "B. He was a lion\n" +
            "C. He was a cougar      " + "D. He was a tiger";
        /*        riddleFirst[2] = "A. He was a cheetah\n" +
                    "B. He was a lion\n" +
                    "C. He was a cougar\n" + "D. He was a tiger";*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && count < 1)
        {
            count++;
            if (count == riddleFirst.Length)
            {
                count = 0;
                isTouch = false;
            }
        }
      
        if (isTouch)
        {
            GetAnwser();
        }

        if (isTouch && !isCorrect)
        {
            UIManager.ShowGuild(riddleFirst[count]);
        }
        else if(isTouch && isCorrect)
        {
            UIManager.OffGuild();
            riddleSecond.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void GetAnwser()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isCorrect = true;
            healthManager.currentHealth += 5;
            player.GetComponent<PlayerController>().ToggleMove();
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            isCorrect = false;
            countTurn++;
            healthManager.HurtPlayer(damageToGive);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch = true;
            gameObject.SetActive(true);
            Debug.Log("cham riddle");
            player.GetComponent<PlayerController>().ToggleMove();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isCorrect)
            {
                isTouch = false;
                UIManager.OffGuild();
                //gameObject.SetActive(false);
            }
            else
            {
                Update();
            }

        }

    }
}
