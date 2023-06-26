using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratulationController : MonoBehaviour
{
    private bool isDone = false;
    private string[] finalChallenge;
    [SerializeField]
    private GameObject wizard;
    [SerializeField]
    private GameObject summer;
    [SerializeField]
    private GameObject necklace;
    private int count = 0;
    private int isChoose = 0;
    private UIManager UIManager;

    void Start()
    {
        isDone = false;
        gameObject.SetActive(false);
        wizard.SetActive(false);
        summer.SetActive(false);
        UIManager = FindObjectOfType<UIManager>();
        finalChallenge = new string[5];
        finalChallenge[0] = "Wizard (happy): Congratulation hero! You have passed all of challenges and found the Summer's necklace!\n";
        finalChallenge[1] = "Wizard: Now, you have to choose between Summer cate and the last piece";
        finalChallenge[2] = "Player (nervous): What should I choose? My friend Summer or the piece?";
        finalChallenge[3] = "Summer: Choose the piece!";
        finalChallenge[4] = "Wizard: What do you choose?\n" +
                            "(Press H for Summer and K for the piece)\n" +
                            "A. Summer cat\t B. The last piece";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count == finalChallenge.Length)
            {
                count = 0;
                isDone = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            isChoose = 1;
            gameObject.SetActive(false) ;
            wizard.SetActive(false);
            summer.SetActive(true);
            necklace.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            isChoose = 2;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Map1"));
        }
        if (isDone && isChoose == 0)
        {
            UIManager.ShowGuild(finalChallenge[count]);
        }
        else
        {
            UIManager.OffGuild();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDone = true;
            gameObject.SetActive(true);
            wizard.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            count = 4;
            isDone = false;
            UIManager.OffGuild();
        }
    }
}
