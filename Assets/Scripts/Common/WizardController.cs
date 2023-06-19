using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WizardController : MonoBehaviour
{
    public GameObject homePosition0;
    private int pos = -1;
    [SerializeField]
    private int speed;
    Boolean firstTouch = true;
    private Boolean m_FacingRight = false;

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

        Debug.Log("f: " + m_FacingRight);

        if (homePosition.transform.position.x - transform.position.x > 0 && m_FacingRight == true)
        {
            Flip();
        }
        else if (homePosition.transform.position.x - transform.position.x < 0 && m_FacingRight == false)
        {
            Flip();
        }
    }

    public void SetPos(int i)
    {
        pos = i;
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
}
