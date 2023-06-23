using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowG_Attack : MonoBehaviour
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.ShowGuild("There is an enemy ahead. Press T to attack!!!");
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
