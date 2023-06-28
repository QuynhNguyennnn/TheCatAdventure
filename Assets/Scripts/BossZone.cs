using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZone : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    PlayerController controller;
    bool isMove = false;
    [SerializeField]
    private GameObject playerStoped;
    Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        
        controller = player.GetComponent<PlayerController>();
        animator = player.GetComponent<Animator>();
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, playerStoped.transform.position, 5 * Time.deltaTime);
            animator.SetFloat("moveX", playerStoped.transform.position.x - player.transform.position.x);
            animator.SetFloat("moveY", playerStoped.transform.position.y - player.transform.position.y);
        }
        
        if (Vector2.Distance(player.transform.position, playerStoped.transform.position) == 0)
        {
            isMove = false;

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isMove = true;
            controller.ToggleMove();
        }
    }

    public bool Change()
    {
        return isMove;
    }
}
