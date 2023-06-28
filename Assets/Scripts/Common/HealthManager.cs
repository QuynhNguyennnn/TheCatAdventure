using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private Animator myAnimator;


    private bool flashActive;
    [SerializeField]
    private float flashLenght = 0f;
    private float flashCounter = 0f;

    private float dieTime = 3f;
    private float dieCounter = 3f;
    private bool isDie;
    PlayerController controller;
    Rigidbody2D rb;


    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            dieCounter -= Time.deltaTime;
            Debug.Log("hoho");
            if (dieCounter <= 0)
            {
                Debug.Log("haha");
                myAnimator.SetBool("isDie", false);
                gameObject.SetActive(false);
                isDie = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (flashActive)
        {
            if (flashCounter > flashLenght * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            } 
            else if (flashCounter > flashLenght * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            } else if (flashCounter > 0f) {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime; 
        }
        
    }

    public void HurtPlayer(int damageToGive)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageToGive;
            flashActive = true;
            flashCounter = flashLenght;
        }

        if (currentHealth <= 0 && isDie == false)
        {
            Debug.Log("hihi");
            controller.ToggleMove();
            dieCounter = dieTime;
            myAnimator.SetBool("isDie", true);
            isDie = true;
            rb.isKinematic = true;

        }
    }
}
