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
        gameTimer = 40 + (10 * GameStats.level);
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
                GameStats.maxLevel = GameStats.level;
                GameStats.level = 1;
                GameStats.gameLoss = true;
                menus.ToggleMenu();

            }
        }
        if (Input.GetKeyUp(KeyCode.R))
                {
                    gameTimer = 0;
                    timerEnded = true;
                    DisplayTime(gameTimer);
                    playerMovement.ToggleMovement();
                    GameStats.maxLevel = GameStats.level;
                    GameStats.level = 1;
                    GameStats.gameLoss = true;
                    menus.ToggleMenu();

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

