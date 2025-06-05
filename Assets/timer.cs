using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 5f; 
    public TMP_Text timerText;
    private PlayerMovement playerMovement;
    public bool timerEnded = false;

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
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
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

