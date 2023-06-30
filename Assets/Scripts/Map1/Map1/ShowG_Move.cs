using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowG_Move : MonoBehaviour
{
    UIManager manager;
    string conver;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();


        string type = PlayerPrefs.GetString("Type");
        Debug.Log(type);

        if (type.CompareTo("Map5_InsideHouse1") == 0)
        {
            conver = "A dream huh??";
        } else
        {
            conver = "Use arrow keys or A, S, D, W to move!!!";
        }

        PlayerPrefs.SetString("Type", "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("dacham");
            manager.ShowGuild(conver);
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
