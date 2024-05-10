using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY");
        float playerPositionZ = PlayerPrefs.GetFloat("PlayerPositionZ");

        transform.position = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
