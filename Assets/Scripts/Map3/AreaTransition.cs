using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    private CameraController cameraController;
    public Vector2 newMinPosition;
    public Vector2 newMaxPosition;
    public Vector3 movePlayer;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cameraController.minPosition = newMinPosition;
            cameraController.maxPosition = newMaxPosition;
            other.transform.position += movePlayer;
        }
    }
}
