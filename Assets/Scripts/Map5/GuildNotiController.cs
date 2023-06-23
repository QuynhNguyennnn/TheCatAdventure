using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildNotiController : MonoBehaviour
{
    private UIManager manager;
    private string[] welcome;
    private bool isTouch;
    private int count = 0;
    [SerializeField]
    private GameObject riddleFirst;
    [SerializeField]
    private GameObject riddleSecond;
    [SerializeField]
    private GameObject riddleThird;
    private GameObject attackZone;

    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        riddleFirst.SetActive(false); 
        riddleSecond.SetActive(false);
        riddleThird.SetActive(false);
        welcome = new string[2];
        welcome[0] = "Go to the goddess statue to solve the puzzle and find the final piece!";
        welcome[1] = "Got it!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == welcome.Length)
            {
                count = 0;
                isTouch = false;
            }
        }

        if (isTouch)
        {
            manager.ShowGuild(welcome[count]);
        }
        else
        {
            manager.OffGuild();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.OffGuild();
            Debug.Log("out");
            gameObject.SetActive(false);
            riddleFirst.SetActive(true) ;
        }
    }
}
