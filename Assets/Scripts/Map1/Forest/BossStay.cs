using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStay : MonoBehaviour
{
    [SerializeField]
    private GameObject Deadzone;
    UIManager manager;
    [SerializeField]
    GameObject boss;
    PlayerController player;
    bool isFirstTouch = true;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.OffGuild();
            boss.GetComponent<Boss>().ToggleMove();
            player.ToggleMove();
            isFirstTouch = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isFirstTouch)
        {
            Deadzone.GetComponent<EdgeCollider2D>().enabled = true;
            manager.ShowGuild("Elric: Kill the boss and then continue the journey!");
        } 
    }
}