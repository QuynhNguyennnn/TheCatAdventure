using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    public Text hpText;
    public Text guildText;
    public GameObject chatBox;
    private bool isStop;
    public GameObject stopMenu;

    // Start is called before the first frame update
    void Start()
    {
        isStop = false;
        healthManager = FindObjectOfType<HealthManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isStop)
            {
                Time.timeScale = 0f;
                isStop = true;
                stopMenu.SetActive(true);
            } 
            else
            {
                Time.timeScale = 1f;
                isStop = false;
                stopMenu.SetActive(false);
            }
        }
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
        hpText.text = "HP: "+healthManager.currentHealth+"/"+healthManager.maxHealth;
    }

    public void ShowGuild(string guildTextNew)
    {
        guildText.text = guildTextNew;
        chatBox.SetActive(true);
    }

    public void OffGuild()
    {
        guildText.text = "";
        chatBox.SetActive(false);
    }

    public void SetHel(HealthManager healthManager)
    {
        this.healthManager = healthManager;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        stopMenu.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("aaaaa");
        isStop = false;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isStop = false;
        stopMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
