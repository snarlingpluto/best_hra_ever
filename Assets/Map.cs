using System.Threading;
using UnityEngine;

public class Map : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public bool mapOpen = false;
    public bool movementAllowed = true;
    public bool freeMap;
    public Vector3 savedCamera = new Vector3(0, 0, -10);

    public void Start()
    {
        mapOpen = false;
        freeMap = true;
        playerMovement = FindAnyObjectByType<PlayerMovement>();
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
                    //Timer = Timer - 20
                }
                playerMovement.toggleMovement();

                savedCamera = mainCamera.transform.position;
                mainCamera.transform.position = new Vector3(60, 30, -10);
                mainCamera.orthographicSize = 40;
                mapOpen = true;
                Debug.Log("Map opened");
            }
            else
            {
                playerMovement.toggleMovement();
                movementAllowed = true;
                mainCamera.transform.position = savedCamera;
                mainCamera.orthographicSize = 10;
                mapOpen = false;
                Debug.Log("Map closed");
            }
        }
    }
}
