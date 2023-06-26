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

    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            dieCounter -= Time.deltaTime;
            if (dieCounter <= 0)
            {
                myAnimator.SetBool("isDie", false);
                gameObject.SetActive(false);
                Debug.Log(isDie);
                isDie = false;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            dieCounter = dieTime;
            myAnimator.SetBool("isDie", true);
            isDie = true;
        }
    }
}
