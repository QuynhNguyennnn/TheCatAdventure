using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleToMap3 : MonoBehaviour
{
    bool isTele = false;
    bool isCatMove = false;
    bool isPlayerMove = false;

    UIManager uiManager;

    [SerializeField]
    private GameObject teleGate;
    Animator t_animator;

    [SerializeField]
    private GameObject conver;

    [SerializeField]
    private GameObject leafstep;

    [SerializeField]
    private GameObject player;
    Animator p_animator;

    [SerializeField]
    private GameObject playerStoped;
    PlayerController playerController;

    [SerializeField]
    private GameObject cat;
    CatMoveForest catMove;


    [SerializeField]
    private GameObject wizard;
    bool isWizardAppear = false;
    bool isWizardDisappear = false;
    Animator w_animator;
    float wizardAppearCounter = 5 / 6f;
    float wizardAppearTime = 5 / 6f;
    private float w_d_Time = 5 / 6f;
    private float w_d_Counter = 5 / 6f;

    bool c_first = true;
    bool p_first = true;
    bool w_first = true;
    bool isShowG = false;

    private float teleOpenTime = 4 / 3f;
    private float teleOpenCounter = 4 / 3f;

    private float teleCloseTime = 1f;
    private float teleCloseCounter = 1f;
    private bool teleClose = false;

    int count = 0;

    string[] conversation;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        conversation = new string[6];
        conversation[0] = "Player (curious): Listen! I hear cries from afar. Let's find out what's happening.";
        conversation[1] = "Elric (heartbroken): These cats have no home. They need our help.";
        conversation[2] = "Summer (whispering): Meow... Meow... (We don't need a reason to help.)";
        conversation[3] = "Player (determined): You're right, Summer. There's no need for a reason to help others. Let's assist these cats and defeat the pursuing monster.";
        conversation[4] = "Elric: See you again hero!";
        conversation[5] = "Summer: I go first!";

        catMove = cat.GetComponent<CatMoveForest>();

        playerController = player.GetComponent<PlayerController>();
        playerController.ToggleMove();

        t_animator = teleGate.GetComponent<Animator>();
        p_animator = player.GetComponent<Animator>();
        w_animator = wizard.GetComponent<Animator>();

        leafstep.GetComponent<LeafstepController_Map2>().hasKey = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTele)
        {
            teleGate.SetActive(true);
            teleOpenCounter -= Time.deltaTime;
            if (teleOpenCounter <= 0)
            {
                t_animator.SetBool("IsIdle", true);
                isTele = false;
                isCatMove = true;
            }
        }

        if (isCatMove)
        {
            cat.SetActive(true);
            catMove.SetPos(0);
            isCatMove = false;
        }

        if (cat != null)
        {
            if (Vector2.Distance(cat.transform.position, catMove.GetPos(0).position) == 0 && c_first)
            {
                player.GetComponent<Renderer>().sortingOrder = 3;
                leafstep.GetComponent<Renderer>().sortingOrder = 3;
                isPlayerMove = true;
                c_first = false;
            }

            if (Vector2.Distance(cat.transform.position, catMove.GetPos(1).position) == 0)
            {
                playerController.ToggleMove();
                Destroy(cat);
                conver.SetActive(true);
                Destroy(gameObject);
            }
        }

        if (isPlayerMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, playerStoped.transform.position, 5 * Time.deltaTime);

            if ((playerStoped.transform.position.x - player.transform.position.x) > 0 && playerController.isFlip() == true)
            {
                playerController.Flip();
            }
            else if ((playerStoped.transform.position.x - player.transform.position.x) < 0 && playerController.isFlip() == false)
            {
                playerController.Flip();
            }

            p_animator.SetFloat("moveX", playerStoped.transform.position.x - player.transform.position.x);
            p_animator.SetFloat("moveY", playerStoped.transform.position.y - player.transform.position.y);
        }

        if (Vector2.Distance(player.transform.position, playerStoped.transform.position) == 0 && p_first)
        {
            isPlayerMove = false;
            if (playerController.isFlip())
            {
                playerController.Flip();
            }
            isWizardAppear = true;
            wizardAppearCounter = wizardAppearTime;
            wizard.SetActive(true);
            w_animator.SetBool("isAppear", true);
            p_first = false;
        }

        if (isWizardAppear)
        {
            wizardAppearCounter -= Time.deltaTime;
            if (wizardAppearCounter <= 0)
            {
                w_animator.SetBool("isAppear", false);
                w_animator.SetBool("isIdle", true);
                isShowG = true;
                isWizardAppear = false;
                t_animator.SetBool("IsClose", true);
                teleClose = true;
                teleCloseCounter = teleCloseTime;
            }
        }

        if (teleClose == true)
        {
            teleCloseCounter -= Time.deltaTime;
            if (teleCloseCounter <= 0)
            {
                teleClose = false;
                Destroy(teleGate);
            }
        }

        if (isShowG)
        {
            uiManager.ShowGuild(conversation[count]);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
            }
        }



        if (count == 4 && w_first)
        {
            w_animator.SetBool("isDisappear", true);
            w_d_Counter = w_d_Time;
            isWizardDisappear = true;
            w_first = false;
        }

        if (isWizardDisappear)
        {
            w_d_Counter -= Time.deltaTime;
            if (w_d_Counter <= 0)
            {
                Destroy(wizard);
            }
        }



        if (count == 6)
        {
            catMove.SetPos(1);
            uiManager.OffGuild();
            isShowG = false;
            count++;
        }
    }

    private void Awake()
    {
        isTele = true;
        teleOpenCounter = teleOpenTime;
    }
}
