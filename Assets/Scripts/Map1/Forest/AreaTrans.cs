using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrans : MonoBehaviour
{
    private CameraController controller;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.minPosition = newMinPos;
            controller.maxPosition = newMaxPos;
        }
    }
}
