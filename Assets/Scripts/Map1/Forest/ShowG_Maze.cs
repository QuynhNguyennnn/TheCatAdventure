using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowG_Maze : MonoBehaviour
{
    UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) manager.OffGuild();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.ShowGuild("Mysterious maze with monsters find the little temple in the maze to escape itself.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.OffGuild();
        }
    }
}
