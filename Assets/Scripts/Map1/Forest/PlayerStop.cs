using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    CameraController cameraController;
    PlayerController controller;
    [SerializeField]
    private GameObject DeadZone;
    [SerializeField]
    private GameObject player;

    float zoomSize = 6;
    float zoomSpeed = 1f;
    bool isZoom = false;
    bool isCamMove = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        controller = player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isZoom)
        {
            ZoomCamera(9);
        }

        if (isCamMove)
        {
            MoveCame();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeadZone.SetActive(true);
        cameraController.ToggleIsTarget();
        isZoom = true;
    }

    void ZoomCamera(float target)
    {
        zoomSize += zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize >= 9)
        {
            isZoom = false;
            isCamMove = true;
        }
    }
    
    void MoveCame()
    {
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, DeadZone.transform.position, 10 * Time.deltaTime);
        if (Vector3.Distance(Camera.main.transform.position, DeadZone.transform.position) == 0)
        {
            controller.ToggleMove();
            isCamMove = false;
        }
    }
}
