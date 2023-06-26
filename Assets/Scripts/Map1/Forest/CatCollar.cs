using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatCollar : MonoBehaviour
{
    UIManager manager;

    [SerializeField]
    private GameObject deadZone;

    [SerializeField]
    private GameObject playerStoped;

    CameraController cameraController;

    [SerializeField]
    private GameObject wizard;
    Animator w_animator;
    float wizardAppearCounter = 5 / 6f;
    float wizardAppearTime = 5 / 6f;
    bool isAppear = false;

    [SerializeField]
    private GameObject player;
    PlayerController playerController;
    Animator p_animator;

    [SerializeField]
    private GameObject teleToMap2;

    [SerializeField]
    private GameObject cat;
    bool isCatFirst = true;

    bool isMove = false;

    float zoomSize = 9;
    float zoomSpeed = 1f;
    bool isZoom = false;
    bool isCamMove = false;

    string[] conversation;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();

        conversation = new string[6];

        cameraController = FindObjectOfType<CameraController>();

        w_animator = wizard.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        p_animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerStoped.transform.position.x - player.transform.position.x);
        if (isMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, playerStoped.transform.position, 5 * Time.deltaTime);
            p_animator.SetFloat("moveX", playerStoped.transform.position.x - player.transform.position.x);

            p_animator.SetFloat("moveY", playerStoped.transform.position.y - player.transform.position.y);

            if ((playerStoped.transform.position.x - player.transform.position.x) > 0 && playerController.isFlip() == true)
            {
                Flip();
            }
            else if ((playerStoped.transform.position.x - player.transform.position.x) < 0 && playerController.isFlip() == false)
            {
                Flip();
            }
        }

        if (Vector2.Distance(player.transform.position, playerStoped.transform.position) == 0 && isMove)
        {
            cat.SetActive(true);
            cat.GetComponent<CatMoveForest>().SetPos(0);
            if (playerController.isFlip() == true)
            {
                Flip();
            }
            isMove = false;
        }

        if (Vector2.Distance(cat.transform.position, cat.GetComponent<CatMoveForest>().GetPos(0).position) == 0 && isCatFirst)
        {
            isAppear = true;
            wizard.SetActive(true);
            w_animator.SetBool("isAppear", true);
            wizardAppearCounter = wizardAppearTime;
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
                teleToMap2.SetActive(true);
                Destroy(gameObject);
            }
        }

        if (isZoom)
        {
            ZoomCam(6);
        }

        if (isCamMove)
        {
            MoveCam();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.ToggleMove();
            gameObject.GetComponent<Renderer>().sortingOrder = -1;
            isCamMove = true;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        playerController.SetFacing();
        // Multiply the player's x local scale by -1.
        Vector3 theScale = player.transform.localScale;
        theScale.x *= -1;
        player.transform.localScale = theScale;
    }

    void ZoomCam(float target)
    {
        zoomSize -= zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize <= target)
        {
            isZoom = false;
            isMove = true;
            deadZone.SetActive(false);
        }
    }

    void MoveCam()
    {
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10), 10 * Time.deltaTime);
        if (Vector3.Distance(Camera.main.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10)) == 0)
        {
            cameraController.ToggleIsTarget();
            isCamMove = false;
            isZoom = true;
        }
    }
}
