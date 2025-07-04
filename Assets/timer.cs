using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Data;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float gameTimer;
    public TMP_Text timerText;
    private PlayerMovement playerMovement;
    private Menus menus;
    public bool timerEnded = false;
    public float cooldownTimer = 1f;

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        menus = FindAnyObjectByType<Menus>();
        if (GameStats.level < 3)
        {
            gameTimer = 50 + 5 * (GameStats.level - 1);
        }
        if (GameStats.level < 5 && GameStats.level > 2)
        {
            gameTimer = 55 + 10 * (GameStats.level-3);
        }
        if (GameStats.level > 4)
        {
            gameTimer = 165 - 15 * (GameStats.level - 5);
        }
    }
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (GameStats.cooldown && cooldownTimer <= 0)
        {
            GameStats.cooldown = false;
        }
        if (gameTimer > 0)
        {
            if (!GameStats.cooldown && !GameStats.mainMenuOpen)
            {
                gameTimer -= Time.deltaTime;
            }
            DisplayTime(gameTimer);
        }
        else
        {
            if (!timerEnded)
            {
                gameTimer = 0;
                timerEnded = true;
                DisplayTime(gameTimer);
                playerMovement.ToggleMovement();
                GameStats.gameLoss = true;
                menus.ToggleMenu();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void MapTimeDecrease()
    {
        gameTimer -= 20;
    }
    public void setTime()
    {
        /* if (GameStats.level =< 8)
         {
             gameTimer = 120 - (GameStats.level - 8) * 15;
         }
         else
         {
             gameTimer = GameStats.level * 15;    
         } */
    } 
}

