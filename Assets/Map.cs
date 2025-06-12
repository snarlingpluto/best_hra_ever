using System.Threading;
using UnityEngine;

public class Map : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private CountdownTimer countdownTimer;
    public bool mapOpen = false;
    public bool freeMap;
    public Vector3 savedCamera = new Vector3(0, 0, -10);

    public void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        countdownTimer = FindAnyObjectByType<CountdownTimer>();
        mapOpen = false;
        freeMap = true;
        savedCamera = new Vector3(0, 0, -10);
    }

    private void Update()
    {
        Camera mainCamera = playerMovement.mainCamera;

        if (Input.GetKeyUp(KeyCode.M))
        {
            if (!mapOpen)
            {
                if (freeMap)
                {
                    freeMap = false;
                }
                else
                {
                    countdownTimer.MapTimeDecrease();
                }
                playerMovement.ToggleMovement();

                savedCamera = mainCamera.transform.position;
                mainCamera.transform.position = new Vector3(48, 27, -10);
                mainCamera.orthographicSize = 36;
                mapOpen = true;
                Debug.Log("Map opened");
            }
            else
            {
                playerMovement.ToggleMovement();
                mainCamera.transform.position = savedCamera;
                mainCamera.orthographicSize = 9;
                mapOpen = false;
                Debug.Log("Map closed");
            }
        }
    }
}
