using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowG_Maze : MonoBehaviour
{
    UIManager manager;
    bool isTouch;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            manager.ShowGuild("Mysterious maze with monsters find the little temple in the maze to escape itself.");
        }
        else
        {
            manager.OffGuild();
        }

        if (Input.GetKeyDown(KeyCode.Space)) isTouch = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
