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
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject bossStay;


    float zoomSize = 6;
    float zoomSpeed = 1f;
    bool isZoom = false;
    bool isCamMove = false;
    bool isBossAxist = false;
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
            ZoomCam(8);
        }

        if (isCamMove)
        {
            MoveCam();
        }

        if (isBossAxist)
        {
            boss.SetActive(true);
            boss.GetComponent<Boss>().ToggleGoHome();
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeadZone.SetActive(true);
        DeadZone.GetComponent<EdgeCollider2D>().enabled = false;
        cameraController.ToggleIsTarget();
        isZoom = true;
        bossStay.SetActive(true);
    }

    void ZoomCam(float target)
    {
        zoomSize += zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize >= target)
        {
            isZoom = false;
            isCamMove = true;
        }
    }
    
    void MoveCam()
    {
        Debug.Log(DeadZone.transform.position);
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, DeadZone.transform.position, 10 * Time.deltaTime);
        if (Vector3.Distance(Camera.main.transform.position, DeadZone.transform.position) == 0)
        {

            isCamMove = false;
            isBossAxist = true;
        }
    }
}
