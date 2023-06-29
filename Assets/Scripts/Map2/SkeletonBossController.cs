using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBossController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public GameObject homePosition;
    PlayerController player;
    bool isMove = false;

    [SerializeField]
    private float speed = 0f;
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
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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

    public void SetMove()
    {
        isMove = true;
    }
}
