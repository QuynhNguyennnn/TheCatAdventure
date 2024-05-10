using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopMap2 : MonoBehaviour
{
    [SerializeField]
    private GameObject DeadZone;
    [SerializeField]
    private GameObject player;
    private UIManager manager;
    SkeletonBossController bossController;


    float zoomSize = 6;
    float zoomSpeed = 1f;
    bool isZoom = false;
    bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        bossController = FindObjectOfType<SkeletonBossController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZoom)
        {
            ZoomCam(9);
        }

        if (isTouch && Input.GetKeyDown(KeyCode.Space))
        {
            manager.OffGuild();
            bossController.SetMove();
            player.GetComponent<PlayerController>().ToggleMove();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeadZone.SetActive(true);
        isZoom = true;
    }

    void ZoomCam(float target)
    {
        zoomSize += zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize >= target)
        {
            isZoom = false;
            manager.ShowGuild("Elric: Kill the boss and then continue the journey!");
            isTouch = true;
        }
    }
}
