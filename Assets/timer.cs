using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Data;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime;
    public TMP_Text timerText;
    private PlayerMovement playerMovement;
    private Menus menus;
    public bool timerEnded = false;

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        menus = FindAnyObjectByType<Menus>();
        setTime();
        totalTime = 90f;
    }
    private void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            DisplayTime(totalTime);
        }
        else
        {
            if (!timerEnded)
            {
                totalTime = 0;
                timerEnded = true;
                DisplayTime(totalTime);
                playerMovement.toggleMovement();
                menus.toggleMenu();

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void setTime()
    {
       /* if (Score =< 8)
        {
            totalTime = 120 - (Score - 8) * 15;
        }
        else
        {
            totalTime = Score * 15;    
        } */
    } 
}

