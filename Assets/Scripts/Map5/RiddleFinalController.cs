using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private GameObject Congratulation;
    [SerializeField]
    private GameObject player;
    private PlayerController playerController;
    Animator p_animator;

    bool isMove = false;
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        healthManager = FindObjectOfType<HealthManager>();
        isTouch = false;
        playerController = player.GetComponent<PlayerController>();
        p_animator = player.GetComponent<Animator>();
        count = 0;
        countTurn = 0;
        riddleThird = new string[2];
        riddleThird[0] = "Press H for A anwser, J for B, K for C, L for D";
        riddleThird[1] = "What do you get when you cross a black cat and a lemon\n" +
            " A. A black lemon           B. A lemonade\n C. A citrus cat            D. A sour puss";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && count < 1)
        {
            count++;
            if (count == riddleThird.Length)
            {
                count = 0;
                isTouch = false;
            }
        }

        if (isTouch)
        {
            GetAnwser();
            UIManager.ShowGuild(riddleThird[count]);

        }

        if (isTouch && isCorrect)
        {
            UIManager.OffGuild();
            Congratulation.SetActive(true);
            isMove = true;
        }

        if (isMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, Congratulation.transform.position, 5 * Time.deltaTime);
            p_animator.SetFloat("moveX", Congratulation.transform.position.x - player.transform.position.x);

            p_animator.SetFloat("moveY", Congratulation.transform.position.y - player.transform.position.y);

            if ((Congratulation.transform.position.x - player.transform.position.x) > 0 && playerController.isFlip() == true)
            {
                playerController.Flip();
            }
            else if ((Congratulation.transform.position.x - player.transform.position.x) < 0 && playerController.isFlip() == false)
            {
                playerController.Flip();
            }
        }

        if(isMove && Vector2.Distance(player.transform.position, Congratulation.transform.position) == 0)
        {
            gameObject.SetActive(false);
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
        if (collision.CompareTag("Player"))
        {
            isTouch = true;
            player.GetComponent<PlayerController>().ToggleMove();
            Debug.Log("cham riddle 3");
        }
    }
}
