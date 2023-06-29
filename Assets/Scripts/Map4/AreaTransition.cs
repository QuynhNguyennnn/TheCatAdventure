using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.minPosition = newMinPos;
            cam.maxPosition = newMaxPos;
        }
    }
}
