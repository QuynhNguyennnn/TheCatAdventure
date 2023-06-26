using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafstepController_Map2 : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private PlayerController player;
    private Boolean m_FacingRight = false;
    [SerializeField]
    public Boolean hasKey = false;

    [SerializeField]
    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey)
        {
            FollowPlayer();
        }else
        {
            Idle();
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));

        if (target.position.x - transform.position.x > 0 && m_FacingRight == true)
        {
            Flip();
        }
        else if (target.position.x - transform.position.x < 0 && m_FacingRight == false)
        {
            Flip();
        }
        if (player.isFlip() == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position - new Vector3(1, -1, 0), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position - new Vector3(-1, -1, 0), speed * Time.deltaTime);
        }

    }

    private void Idle()
    {
        myAnim.SetFloat("moveX", (target.position.x));
        myAnim.SetFloat("moveY", (target.position.y));

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
