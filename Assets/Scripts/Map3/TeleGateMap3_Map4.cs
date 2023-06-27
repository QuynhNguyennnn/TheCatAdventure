using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleGateMap3_Map4 : MonoBehaviour
{
    public GameObject player;
    public GameObject leafstep;
    private float teleCloseTime = 1f;
    private float teleCloseCounter = 1f;
    private float wait = .5f;
    Animator animator;
    bool isClose = false;
    bool isLeafstepMove = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose)
        {
            wait -= Time.deltaTime;
            if (wait <= 0)
            {
                animator.SetBool("IsClose", true);
                teleCloseCounter -= Time.deltaTime;
                Debug.Log(teleCloseCounter);
                if (teleCloseCounter <= 0)
                {
                    PlayerPrefs.SetFloat("PlayerPositionX", -54.96f);
                    PlayerPrefs.SetFloat("PlayerPositionY", -103.58f);
                    PlayerPrefs.SetFloat("PlayerPositionZ", 0);

                    SceneManager.LoadScene("Map4");
                }
            }
        }

        if (isLeafstepMove)
        {
            leafstep.transform.position = Vector2.MoveTowards(leafstep.transform.position, transform.position, leafstep.GetComponent<LeafstepController_Map2>().speed * Time.deltaTime);
        }

        if (Vector2.Distance(leafstep.transform.position, transform.position) == 0 && isLeafstepMove)
        {
            isLeafstepMove = false;
            teleCloseCounter = teleCloseTime;
            leafstep.SetActive(false);
            isClose = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.SetActive(false);
            leafstep.GetComponent<LeafstepController_Map2>().hasKey = false;
            isLeafstepMove = true;
        }
    }
}
