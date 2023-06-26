using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    CloneController cController;
    Boss b_Controller;
    [SerializeField]
    private GameObject necklaceMap4;

    private bool flashActive;
    [SerializeField]
    private float flashLenght = 0f;
    private float flashCounter = 0f;
    bool isE_Controller = true;

    private SpriteRenderer enemySprite;
    // Start is called before the first frame update
    void Start()
    {
        cController = GetComponent<CloneController>();
        if (cController == null)
        {
            b_Controller = GetComponent<Boss>();
            isE_Controller = false;
        }
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLenght * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtEnemy(int damageToGive)
    {

        flashActive = true;
        flashCounter = flashLenght;


        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            if (isE_Controller)
            {
                cController.isDie();
            }
            else
            {
                Debug.Log("Boss was died");
                cController.isDie();
                necklaceMap4.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
