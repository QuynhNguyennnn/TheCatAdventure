using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleEnd : MonoBehaviour
{
    bool isTele = false;
    bool isCatMove = false;
    bool isPlayerMove = false;

    UIManager uiManager;

    [SerializeField]
    private GameObject teleGate;
    Animator t_animator;

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
    private AudioSource audio;
    [SerializeField]
    private AudioClip congra;


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
    bool isShowG = false;

    private float teleOpenTime = 4 / 3f;
    private float teleOpenCounter = 4 / 3f;

    private float teleCloseTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audio.clip = congra;
        audio.loop = true;
        uiManager = FindObjectOfType<UIManager>();

        catMove = cat.GetComponent<CatMoveForest>();

        playerController = player.GetComponent<PlayerController>();
        playerController.ToggleMove();

        leafstep.GetComponent<LeafstepController_Map2>().hasKey = true;

        t_animator = teleGate.GetComponent<Animator>();
        p_animator = player.GetComponent<Animator>();
        w_animator = wizard.GetComponent<Animator>();
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
                isPlayerMove = true;
                player.GetComponent<Renderer>().sortingOrder = 4;
                leafstep.GetComponent<Renderer>().sortingOrder=4;
            }
        }

        if (isPlayerMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, playerStoped.transform.position, 5 * Time.deltaTime);
            p_animator.SetFloat("moveX", playerStoped.transform.position.x - player.transform.position.x);
            p_animator.SetFloat("moveY", playerStoped.transform.position.y - player.transform.position.y);
        }

        if (Vector2.Distance(player.transform.position, playerStoped.transform.position) == 0 && p_first)
        {
            p_first = false;
            isCatMove = true;
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
                player.GetComponent<Renderer>().sortingOrder = 4;
                c_first = false;

                isPlayerMove = false;
                isWizardAppear = true;
                wizardAppearCounter = wizardAppearTime;
                wizard.SetActive(true);
                w_animator.SetBool("isAppear", true);
            }
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
                isShowG = true;
                audio.Play();
            }
        }

        if(isShowG)
        {    
            uiManager.ShowGuild("CONGRATULATIONS YOU COMPLETE THE GAME. PRESS SPACE TO BACK TO STANDBY SCREEN.");
        }
        
        if(isShowG && Input.GetKeyDown(KeyCode.Space))
        {
            audio.Stop();
            SceneManager.LoadScene("Menu");
        }
    }

    private void Awake()
    {
        isTele = true;
        teleOpenCounter = teleOpenTime;
    }
}
