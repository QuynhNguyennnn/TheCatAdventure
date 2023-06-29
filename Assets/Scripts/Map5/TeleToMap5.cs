using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleToMap5 : MonoBehaviour
{
    bool isTele = false;
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

    bool p_first = true;
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

        conversation = new string[2];

        conversation[0] = "Elric: Choose according to your heart!!!";
        conversation[1] = "Player: Summer! Where are you?";

        playerController = player.GetComponent<PlayerController>();

        player.GetComponent<PlayerController>().ToggleMove();

        t_animator = teleGate.GetComponent<Animator>();
        p_animator = player.GetComponent<Animator>();

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
                isPlayerMove = true;
                player.GetComponent<Renderer>().sortingOrder = 3;
                leafstep.GetComponent<Renderer>().sortingOrder = 4;
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
            isShowG = true;
            p_first = false;
        }

        if (teleClose)
        {
            teleCloseCounter -= Time.deltaTime;
            if (teleCloseCounter <= 0)
            {
                player.GetComponent<PlayerController>().ToggleMove();
                conver.SetActive(true);
                Destroy(teleGate);
                Destroy(gameObject);
            }
        }

        if (isShowG && count < 2)
        {
            uiManager.ShowGuild(conversation[count]);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
            }
        }

        Debug.Log(count);

        if (count == 2 && teleClose == false)
        {
            uiManager.OffGuild();
            teleClose = true;
            t_animator.SetBool("IsClose", true);
            teleCloseCounter = teleCloseTime;
        }
    }

    private void Awake()
    {
        isTele = true;
        teleOpenCounter = teleOpenTime;
    }
}
