using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CatMove : MonoBehaviour
{
    public GameObject homePosition;
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
        }
    }

    
}
