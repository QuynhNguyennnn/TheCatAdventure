using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NecklaceController : MonoBehaviour
{
    private RiddleFinalController controller;
    private bool isTouch = false;
    void Start()
    {
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch=true;
            gameObject.SetActive(false);
            Debug.Log("mnmn");
        }
    }

    public bool IsTouch()
    {
        return isTouch;
    }
}
