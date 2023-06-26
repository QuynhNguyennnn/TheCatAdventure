using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator myAnima;
    [SerializeField]
    private Transform homePosition;
    private Transform target;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float maxRange = 0;
    [SerializeField]
    private float minRange = 0;
    void Start()
    {
        myAnima = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(transform.position, target.position) >= minRange)
        {
            FollowPlayer();
        } else if (Vector3.Distance(transform.position, target.position) >= maxRange)
        {
            ReturnHomePosition();
        }
    }

    public void FollowPlayer()
    {
        myAnima.SetBool("isMoving", true);
        myAnima.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnima.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void ReturnHomePosition()
    {
        myAnima.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        myAnima.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePosition.position) == 0)
        {
            myAnima.SetBool("isMoving", false);
        }
    }
}
