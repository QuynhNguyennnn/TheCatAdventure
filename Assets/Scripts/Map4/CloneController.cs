using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private Boolean m_FacingRight = false;
    public GameObject homePosition;
    PlayerController player;

    [SerializeField]
    private float speed = 0f;
    bool isGoHome = false;
    bool isMove = false;

    [SerializeField]
    private GameObject catCollar;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoHome)
        {
            GoHome();
        }

        if (isMove)
        {
            FollowPlayer();
        }

    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", target.position.x - transform.position.x);
        myAnim.SetFloat("moveY", target.position.y - transform.position.y);

        if (target.position.x - transform.position.x > 0 && m_FacingRight == true)
        {
            Flip();
        }
        else if (target.position.x - transform.position.x < 0 && m_FacingRight == false)
        {
            Flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        myAnim.SetBool("isMoving", true);
        if (transform.position.x - homePosition.transform.position.x > 0 && m_FacingRight == false)
        {
            Flip();
        }
        else if (transform.position.x - homePosition.transform.position.x < 0 && m_FacingRight == true)
        {
            Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, homePosition.transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, homePosition.transform.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
            ToggleGoHome();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AttackRange" && player.isAttack1())
        {
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }

    public void SetHomePosition(GameObject HomePosition)
    {
        homePosition = HomePosition;
    }

    public void isDie()
    {
        Destroy(homePosition);
    }

    public void ToggleGoHome()
    {
        isGoHome = !isGoHome;
    }

    public void DropCatCollar()
    {
        catCollar.SetActive(true);
        catCollar.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    public void ToggleMove()
    {
        isMove = !isMove;
    }
}
