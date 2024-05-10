using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStapMap4 : MonoBehaviour
{
    [SerializeField]
    private GameObject Deadzone;
    UIManager manager;
    [SerializeField]
    GameObject boss;
    PlayerController player;
    bool isFirstTouch = true;
    bool isTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        Debug.Log(manager);
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouch)
        {
            manager.OffGuild();
            boss.GetComponent<CloneController>().ToggleMove();
            player.ToggleMove();
            isTouch = false;
        }
        Debug.Log(isFirstTouch);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Clone") && isFirstTouch)
        {
            Debug.Log("dacham");
            Deadzone.GetComponent<EdgeCollider2D>().enabled = true;
            manager.ShowGuild("Elric: Kill the boss and then continue the journey!");
            isTouch = true;
            isFirstTouch = false;
        }
    }
}
