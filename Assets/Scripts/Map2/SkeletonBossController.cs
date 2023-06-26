using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBossController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private Boolean m_FacingRight = false;
    public GameObject homePosition;
    PlayerController player;

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0;
    [SerializeField]
    private float minRange = 0;
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
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }

    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", target.position.x - transform.position.x);
        myAnim.SetFloat("moveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", homePosition.transform.position.x - transform.position.x);
        myAnim.SetFloat("moveY", homePosition.transform.position.y - transform.position.y);

        transform.position = Vector3.MoveTowards(transform.position, homePosition.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePosition.transform.position) == 0)
            myAnim.SetBool("isMoving", false);
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
}
