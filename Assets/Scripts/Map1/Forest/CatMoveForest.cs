using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveForest : MonoBehaviour
{
    public GameObject homePosition0;
    public GameObject homePosition1;
    private int pos;
    [SerializeField]
    private int speed;

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
        else if (pos == 1)
        {
            MoveTo(homePosition1);
        }
    }

    public void MoveTo(GameObject homePosition)
    {
        animator.SetFloat("moveX", (homePosition.transform.position.x - transform.position.x));
        animator.SetFloat("moveY", (homePosition.transform.position.y - transform.position.y));

        if (transform.position != homePosition.transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.transform.position, speed * Time.deltaTime);
        }
    }

    public void SetPos(int i)
    {
        pos = i;
    }

    public Transform GetPos(int i)
    {
        if(i == 0)
        {
            return homePosition0.transform;
        } else
        {
            return homePosition1.transform;
        }

    }
}
