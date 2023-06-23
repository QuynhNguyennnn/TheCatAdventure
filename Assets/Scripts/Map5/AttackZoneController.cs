using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZoneController : MonoBehaviour
{
    UIManager manager;
    [SerializeField]
    private GameObject slime;
    [SerializeField]
    private GameObject guild;
    [SerializeField]
    private GameObject riddleFirst;
    [SerializeField]
    private GameObject riddleSecond;
    [SerializeField]
    private GameObject riddleThird;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        guild.SetActive(false); 
        riddleFirst.SetActive(false);
        riddleSecond.SetActive(false);
        riddleThird.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (slime == null)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.SetActive(true);
            manager.ShowGuild("Let's kill the enemy to continue the journey!!!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            manager.OffGuild();
            riddleSecond.SetActive(true);
        }
    }
}
