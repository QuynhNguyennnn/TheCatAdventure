using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthManager;
    private float waitToHurt = 2f;
    private bool isTouching;

    [SerializeField]
    private int damageToGive = 0;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*f (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0 )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManager.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (collision.gameObject.GetComponent<HealthManager>().currentHealth > 0)
            {

                // Destroy(collision.gameObject);
                // collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
                //reloading = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }

   
}
