using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBoxPosition : MonoBehaviour
{
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(myCamera.transform.position.x - 0.1f, myCamera.transform.position.y - 3f, myCamera.transform.position.z + 10f);   
    }
}
