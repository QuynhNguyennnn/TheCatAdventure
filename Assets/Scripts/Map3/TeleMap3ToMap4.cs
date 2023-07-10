using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleMap3ToMap4 : MonoBehaviour
{
    bool isStart = false;
    int count = 0;
    int countDo = 0;
    string[] conversation;

    UIManager manager;

    [SerializeField]
    private GameObject player;
    Animator p_animator;
    PlayerController playerController;

    [SerializeField]
    private GameObject playerStoped;
    bool isMove = false;

    [SerializeField]
    private GameObject cat;
    bool isCatFirst = true;

    [SerializeField]
    private GameObject wizard;
    Animator w_animator;
    private float wizardAppearCounter = 5 / 6f;
    private float wizardAppearTime = 5 / 6f;
    private float w_d_Time = 5 / 6f;
    private float w_d_Counter = 5 / 6f;
    bool isAppear = false;
    bool isWizardD = false;

    [SerializeField]
    private GameObject tele;
    Animator t_animator;
    private float teleOpenTime = 4 / 3f;
    private float teleOpenCounter = 4 / 3f;
    bool isOpen = false;

    [SerializeField]
    private GameObject deadZone;
    bool isZoom = false;
    float zoomSize = 8;
    float zoomSpeed = 1f;

    [SerializeField]
    private GameObject catRed;

    // Start is called before the first frame update
    void Start()
    {
        conversation = new string[3];
        conversation[0] = "Elric: I will open the gate!";
        conversation[1] = "Summer: Meow! (I go!)";
        conversation[2] = "Elric: I go too!";

        p_animator = player.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        w_animator = wizard.GetComponent<Animator>();
        t_animator = tele.GetComponent<Animator>();

        manager = FindObjectOfType<UIManager>();

        playerController.ToggleMove();

        isZoom = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isZoom)
        {
            ZoomCam(6);
        }

        if (isMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, playerStoped.transform.position, 5 * Time.deltaTime);
            p_animator.SetFloat("moveX", playerStoped.transform.position.x - player.transform.position.x);

            p_animator.SetFloat("moveY", playerStoped.transform.position.y - player.transform.position.y);

            if ((playerStoped.transform.position.x - player.transform.position.x) > 0 && playerController.isFlip() == true)
            {
                playerController.Flip();
            }
            else if ((playerStoped.transform.position.x - player.transform.position.x) < 0 && playerController.isFlip() == false)
            {
                playerController.Flip();
            }
        }

        if (Vector2.Distance(player.transform.position, playerStoped.transform.position) == 0 && isMove)
        {
            cat.SetActive(true);
            cat.GetComponent<CatMoveForest>().SetPos(0);
            if (playerController.isFlip() == false)
            {
                playerController.Flip();
            }
            isMove = false;
        }

        if (Vector2.Distance(cat.transform.position, cat.GetComponent<CatMoveForest>().GetPos(0).position) == 0 && isCatFirst)
        {
            isAppear = true;
            wizard.SetActive(true);
            w_animator.SetBool("isAppear", true);
            wizardAppearCounter = wizardAppearTime;
            catRed.GetComponent<TheresiaController>().ToggleMove();
            isCatFirst = false;
        }

        if (isAppear)
        {
            wizardAppearCounter -= Time.deltaTime;
            if (wizardAppearCounter <= 0)
            {
                w_animator.SetBool("isAppear", false);
                w_animator.SetBool("isIdle", true);
                isAppear = false;
                isStart = true;
            }
        }

        if (isStart && count < 3)
        {
            manager.ShowGuild(conversation[count]);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isStart)
        {
            count++;
        }

        if (countDo == 0 && count == 0 && isStart)
        {
            tele.SetActive(true);
            teleOpenCounter = teleOpenTime;
            isOpen = true;
            countDo++;
        }

        if (isOpen && isStart)
        {
            teleOpenCounter -= Time.deltaTime;
            if (teleOpenCounter <= 0)
            {
                isOpen = false;
                t_animator.SetBool("IsIdle", true);
            }
        }

        if (countDo == 1 && count == 1 && isStart)
        {
            cat.GetComponent<CatMoveForest>().SetPos(1);
            countDo++;
        }

        if (Vector2.Distance(cat.transform.position, cat.GetComponent<CatMoveForest>().GetPos(1).position) == 0)
        {
            cat.SetActive(false);
        }

        if (countDo == 2 && count == 2 && isStart)
        {
            w_d_Counter = w_d_Time;
            w_animator.SetBool("isDisappear", true);
            isWizardD = true;
            countDo++;
        }

        if (isWizardD && isStart)
        {
            Debug.Log(w_d_Counter);
            w_d_Counter -= Time.deltaTime;
            if (w_d_Counter <= 0)
            {
                Destroy(wizard);
                isWizardD = false;
            }
        }
        if (count >= 3 && isWizardD == false && isStart)
        {
            manager.OffGuild();
            playerController.ToggleMove();
            Destroy(gameObject);
        }
    }

    public bool Change()
    {
        return isZoom;
    }

    void ZoomCam(float target)
    {
        zoomSize -= zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize <= target)
        {
            isZoom = false;
            player.GetComponent<PlayerController>().ToggleMove();
            deadZone.SetActive(false);
            isMove = true;
            playerController.ToggleMove();
        }
    }
}
