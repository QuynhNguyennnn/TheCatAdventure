using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnimator;
    private Boolean m_FacingRight = false;

    
    public GameObject attack1;
    [SerializeField]
    private float speed = 0f;

    private float appearTime = 2 / 3f;
    private float appearCounter = 2 / 3f;

    private float attackTime = 2/3f;
    private float attackCounter = 2/3f;
    private bool isAttacking1;

    bool isMove = true;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isMove)
        {
            myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
            // normalized make same speed when push all of above
            myAnimator.SetFloat("moveX", myRB.velocity.x);
            myAnimator.SetFloat("moveY", myRB.velocity.y);
        }
        if (isAttacking1)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0) {
                myAnimator.SetBool("isAttacking1", false);
                isAttacking1 = false;
            }

            appearCounter -= Time.deltaTime;
            if (appearCounter >= (2 / 3f - (2 / 3f)*(3 / 4f)) && appearCounter <= (2 / 3f - (2 / 3f) * (2/4f)))
            {
                attack1.SetActive(true);
            }
            else if (appearCounter <= 0)
            {
                isAttacking1 = false;
                attack1.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            appearCounter = appearTime;
            attackCounter = attackTime;
            myAnimator.SetBool("isAttacking1", true);
            isAttacking1 = true;
        }

        if (myRB.velocity.x > 0 && m_FacingRight == true)
        {
            Flip();
        }
        else if(myRB.velocity.x < 0 && m_FacingRight == false) 
        {
            Flip();
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

    public bool isAttack1()
    {
        return isAttacking1;
    }

    public bool isFlip()
    {
        return m_FacingRight;
    }

    public void ToggleMove()
    {
        isMove = !isMove;
        myRB.velocity = new Vector2(0,0).normalized * speed * Time.deltaTime;
        // normalized make same speed when push all of above
        myAnimator.SetFloat("moveX", myRB.velocity.x);
        myAnimator.SetFloat("moveY", myRB.velocity.y);
    }

    public void SetFacing()
    {
        m_FacingRight = !m_FacingRight;
    }
}
