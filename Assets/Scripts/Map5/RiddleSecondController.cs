using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleSecondController : MonoBehaviour
{
    private UIManager UIManager;
    private HealthManager healthManager;
    private bool isTouch = false;
    private int count = 0;
    private int maxTurn = 4;
    private string[] riddleSecond;
    private int countTurn = 0;
    private int damageToGive = 2;
    private bool isCorrect = false;
    [SerializeField]
    private GameObject guildNoti;
    [SerializeField]
    private GameObject ridderFirst;
    [SerializeField]
    private GameObject ridderThird;

    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        healthManager = FindObjectOfType<HealthManager>();
        isTouch = false;
        guildNoti.SetActive(false);
        ridderFirst.SetActive(false);
        ridderThird.SetActive(false);
        count = 0;
        countTurn = 0;
        riddleSecond = new string[2];
        riddleSecond[0] = "Press H for A anwser, J for B, K for C, L for D";
        riddleSecond[1] = "I have a head like a cat, feet like a cat, a tail like a cat, but I am not a cat. What am I?\n" +
            " A. A lion               B. A kitten\n C. A tiger              D. A leopard";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == riddleSecond.Length)
            {
                count = 0;
                isTouch = false;
            }
        }
        if (!isCorrect) //countTurn < maxTurn && 
        {
            UIManager.ShowGuild(riddleSecond[1]);
            GetAnwser();
        }
        if (isTouch && !isCorrect)
        {
            UIManager.ShowGuild(riddleSecond[count]);
        }
        else
        {
            UIManager.OffGuild();
        }
    }

    private void GetAnwser()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isCorrect = true;
            healthManager.currentHealth += 5;
            if (healthManager.currentHealth > 50)
            {
                healthManager.currentHealth = 50;
            }

        }
         if (Input.GetKeyDown(KeyCode.H))
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
            isTouch = true;
            gameObject.SetActive(true);
            Debug.Log("cham riddle 2");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isCorrect)
            {
                isTouch = false;
                UIManager.OffGuild();
                ridderThird.SetActive(true);
            } else
            {
                Update();
            }
            
        }

    }
}
