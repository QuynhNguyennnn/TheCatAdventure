using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAndMoveCam : MonoBehaviour
{
    float zoomSize;
    float zoomSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        zoomSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ZoomCamera(float target)
    {
        zoomSize += zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = zoomSize;
        if (zoomSize >= target)
        {
            return true;
        }
        else { return false; }
    }

    public bool MoveCame(GameObject gameObject)
    {
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, gameObject.transform.position, 10 * Time.deltaTime);
        if (Vector3.Distance(Camera.main.transform.position, gameObject.transform.position) == 0)
        {
            
            return true;
        }
        else return false;
    }
}
