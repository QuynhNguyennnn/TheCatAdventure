using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnimator;
    private Boolean m_FacingRight = false;

    [SerializeField]
    private float speed = 0f;

    private float attackTime = 2/3f;
    private float attackCounter = 2 / 3f;
    private bool isAttacking1;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
        // normalized make same speed when push all of above
        myAnimator.SetFloat("moveX", myRB.velocity.x);
        myAnimator.SetFloat("moveY", myRB.velocity.y);

        if (isAttacking1)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0) {
                myAnimator.SetBool("isAttacking1", false);
                isAttacking1 = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }

    public Boolean isFlip()
    {
        return m_FacingRight;
    }
}
