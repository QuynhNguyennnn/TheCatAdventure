using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceManagement : MonoBehaviour
{
    public bool hasNecklace = false;
    public bool isTouch = false;

    [SerializeField]
    private GameObject deadZone;
    bool isZoom = false;
    [SerializeField]
    private GameObject player;

    float zoomSize = 9;
    float zoomSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isZoom)
        {
            ZoomCam(6);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().sortingOrder = -1;
            isZoom = true;
            Debug.Log(isZoom);
            player.GetComponent<PlayerController>().ToggleMove();
        }
    }

    public bool Change()
    {
        return isZoom;
    }

    void ZoomCam(float target)
    {
        zoomSize -= zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize <= target)
        {
            isZoom = false;
            player.GetComponent<PlayerController>().ToggleMove();
            deadZone.SetActive(false);
            Destroy(gameObject);
        }
    }
}
