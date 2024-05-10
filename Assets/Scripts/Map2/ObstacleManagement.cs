using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject BridgeCanvas;
    [SerializeField]
    private GameObject LeafstepCanvas;
    private LeafstepController_Map2 leafstepController_Map2;
    private leafstepCanvas leafstepCanvas;

    bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
       leafstepController_Map2 = FindObjectOfType<LeafstepController_Map2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch && leafstepController_Map2.hasKey == false)
        {
            Debug.Log("da cham");
            //LeafstepCanvas.SetActive(false);
            BridgeCanvas.SetActive(true);
        }

        if (isTouch == false)
        {
            //LeafstepCanvas.SetActive(true);
            BridgeCanvas.SetActive(false);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouch = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isTouch = false;
        }
    }


}
