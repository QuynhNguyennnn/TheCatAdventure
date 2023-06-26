using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceManagement : MonoBehaviour
{
    public bool hasNecklace = false;
    public bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            hasNecklace = true;
            Debug.Log("Da nhat");
            gameObject.SetActive(false);
        }
        else
        {
            hasNecklace = false;
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
            isTouch = false;
        }
    }
}