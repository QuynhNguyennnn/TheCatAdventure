using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafstepAreaController : MonoBehaviour
{
    [SerializeField]
    private GameObject BridgeCanvas;
    [SerializeField]
    private GameObject LeafstepCanvas;
    bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            BridgeCanvas.SetActive(false);
            LeafstepCanvas.SetActive(true);
        }
        else
        {
            BridgeCanvas.SetActive(true);
            LeafstepCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
