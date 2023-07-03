using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratulationController : MonoBehaviour
{
    private bool isDone = false;
    private string[] finalChallenge;

    [SerializeField]
    private GameObject wizard;
    Animator w_animator;
    private float wizardAppearCounter = 5 / 6f;
    private float wizardAppearTime = 5 / 6f;
    private float w_d_Time = 5 / 6f;
    private float w_d_Counter = 5 / 6f;
    bool isAppear = false;
    bool isDisappear = false;

    [SerializeField]
    private GameObject tele;
    Animator t_animator;
    private float teleOpenTime = 4 / 3f;
    private float teleOpenCounter = 4 / 3f;
    bool isOpen = false;
    private float teleCloseTime = 1f;
    private float teleCloseCounter = 1f;
    private bool teleClose = false;

    [SerializeField]
    private GameObject summer;
    int isCatMove = 0;

    [SerializeField]
    private GameObject necklace;
    private int count = 0;
    private int isChoose = 0;
    private UIManager UIManager;
    private int canPress = 0;

    [SerializeField]
    private GameObject player;
    Animator p_animator;
    PlayerController playerController;
    private bool isMove;

    void Start()
    {
        w_animator = wizard.GetComponent<Animator>();
        t_animator = tele.GetComponent<Animator>();
        p_animator = player.GetComponent<Animator>();   
        playerController = player.GetComponent<PlayerController>();
        isDone = false;
        UIManager = FindObjectOfType<UIManager>();
        finalChallenge = new string[6];
        finalChallenge[0] = "Wizard (happy): Congratulation hero! You have passed all of challenges and found the Summer's necklace!\n";
        finalChallenge[1] = "Wizard: Now, you have to choose between Summer cate and the last piece";
        finalChallenge[2] = "Player (nervous): What should I choose? My friend Summer or the piece?";
        finalChallenge[3] = "Summer: Choose the piece!";
        finalChallenge[4] = "Wizard: What do you choose?\n" +
                            "(Press H for Summer and K for the piece)\n" +
                            "A. Summer cat\t B. The last piece";
        finalChallenge[5] = "Wizard: Good choice hero, let's go back!";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && count < 4)
        {
            count++;
        }
        Debug.Log(isDone);
        Debug.Log(isChoose);
        if (Input.GetKeyDown(KeyCode.H) && isDone)
        {
            isChoose = 1;
        }
        else if (Input.GetKeyDown(KeyCode.K) && isDone)
        {
            isChoose = 2;
            PlayerPrefs.SetFloat("PlayerPositionX", -2.81f);
            PlayerPrefs.SetFloat("PlayerPositionY", 1.6f);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            PlayerPrefs.SetString("Type", "Map5_InsideHouse1");

            PlayerPrefs.SetInt("Level", 1);

            SceneManager.LoadScene("InsideHouse1");
        }
        if (isDone)
        {
            UIManager.ShowGuild(finalChallenge[count]);
        }
        
        if (isDone && isChoose == 1)
        {
            isChoose = 3;
            isCatMove = 1;
            summer.SetActive(true);
            necklace.SetActive(true);

            count++;
        }

        if (isCatMove == 1)
        {
            summer.GetComponent<CatMoveForest>().SetPos(0);
        }

        if (Vector2.Distance(summer.transform.position, summer.GetComponent<CatMoveForest>().GetPos(0).position) == 0 && canPress == 0)
        {
            
            canPress++;
        }

        if(canPress == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            count++;
        }

        if (count == 6 && isDone)
        {
            isOpen = true;
            tele.SetActive(true);
            isDone = false;
            teleOpenCounter = teleOpenTime;
            UIManager.OffGuild();
        }

        if (isOpen)
        {
            teleOpenCounter -= Time.deltaTime;
            if(teleOpenCounter <= 0)
            {
                isOpen = false;
                t_animator.SetBool("IsIdle", true);
                isCatMove = 2;
            }
        }

        if (isCatMove == 2)
        {
            summer.GetComponent<CatMoveForest>().SetPos(1);
        }

        if (Vector2.Distance(summer.transform.position, summer.GetComponent<CatMoveForest>().GetPos(1).position) == 0 && isDisappear == false)
        {
            summer.SetActive(false);
            isDisappear = true;
            w_d_Counter = w_d_Time;
            w_animator.SetBool("isDisappear", true);
        }

        if (isDisappear)
        {
            w_d_Counter -= Time.deltaTime;
            if (w_d_Counter <= 0)
            {
                isDisappear = false;
                wizard.SetActive(false);
                player.GetComponent<PlayerController>().ToggleMove();
                isMove = true;
            }  
        }

        if (isMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, necklace.transform.position, 5 * Time.deltaTime);
            p_animator.SetFloat("moveX", necklace.transform.position.x - player.transform.position.x);

            p_animator.SetFloat("moveY", necklace.transform.position.y - player.transform.position.y);

            if ((necklace.transform.position.x - player.transform.position.x) > 0 && playerController.isFlip() == true)
            {
                playerController.Flip();
            }
            else if ((necklace.transform.position.x - player.transform.position.x) < 0 && playerController.isFlip() == false)
            {
                playerController.Flip();
            }
        }

        if (necklace.GetComponent<NecklaceController>().IsTouch()) {
            isMove = false;
            player.transform.position = Vector2.MoveTowards(player.transform.position, tele.transform.position, 5 * Time.deltaTime);
            p_animator.SetFloat("moveX", tele.transform.position.x - player.transform.position.x);

            p_animator.SetFloat("moveY", tele.transform.position.y - player.transform.position.y);

            if ((tele.transform.position.x - player.transform.position.x) > 0 && playerController.isFlip() == true)
            {
                playerController.Flip();
            }
            else if ((tele.transform.position.x - player.transform.position.x) < 0 && playerController.isFlip() == false)
            {
                playerController.Flip();
            }
        }

        if (isAppear)
        {
            wizardAppearCounter -= Time.deltaTime;
            if(wizardAppearCounter <= 0)
            {
                w_animator.SetBool("isAppear", false);
                w_animator.SetBool("isIdle", true);
                isAppear = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wizard.SetActive(true);
            isDone = true;
            isAppear = true;
            wizardAppearCounter = wizardAppearTime;
            w_animator.SetBool("isAppear", true);
        }
    }
}
