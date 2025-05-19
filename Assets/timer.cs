using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 90f; 
    public TMP_Text timerText;

    private void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            DisplayTime(totalTime);
        }
        else
        {
            totalTime = 0;
            DisplayTime(totalTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

