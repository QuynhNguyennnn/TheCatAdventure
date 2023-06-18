using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CatMove : MonoBehaviour
{
    public GameObject homePosition0;
    public GameObject homePosition1;
    public GameObject homePosition2;
    private int pos;
    [SerializeField]
    private int speed;
    Boolean firstTouch = true;

    ShowG_FirstMeet firstMeet;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        firstMeet = FindObjectOfType<ShowG_FirstMeet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pos == 0)
        {
            MoveTo(homePosition0);
        }else if (pos == 1)
        {
            MoveTo(homePosition1);
        } else if (pos == 2)
        {
            MoveTo(homePosition2);
        }

        if (transform.position == homePosition2.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public void MoveTo(GameObject homePosition)
    {
        animator.SetFloat("moveX", (homePosition.transform.position.x - transform.position.x));
        animator.SetFloat("moveY", (homePosition.transform.position.y - transform.position.y));

        if (transform.position != homePosition.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, homePosition.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (firstTouch)
            {
                firstMeet.toggleTouch();
            }
            firstTouch = false;
            pos = -1;
        }
    }

    public void SetPos(int i)
    {
        pos = i;
    }
}
