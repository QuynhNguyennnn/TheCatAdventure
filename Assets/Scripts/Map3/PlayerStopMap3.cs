using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopMap3 : MonoBehaviour
{
    [SerializeField]
    private GameObject DeadZone;
    [SerializeField]
    private GameObject player;
    private UIManager manager;
    [SerializeField]
    private GameObject boss;


    float zoomSize = 6;
    float zoomSpeed = 1f;
    bool isZoom = false;
    bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZoom)
        {
            ZoomCam(8);
        }

        if (isTouch && Input.GetKeyDown(KeyCode.Space))
        {
            manager.OffGuild();
            boss.GetComponent<Boss>().ToggleMove();
            player.GetComponent<PlayerController>().ToggleMove();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeadZone.SetActive(true);
        isZoom = true;
        if (player.GetComponent<PlayerController>().isFlip() == false)
        {  
            player.GetComponent<PlayerController>().Flip();
        }
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
