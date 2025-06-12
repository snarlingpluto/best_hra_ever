using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Menus : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject lossMenu;
    public GameObject mainMenu;
    public GameObject logoWhite;
    public GameObject logoBlack;
    public TMP_Text maxLevelDisplay;
    public float mainMenuSwitch = 0;
    public bool currentLogoBlack = true;
    public bool lossMenuOpen;
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        lossMenuOpen = false;
        lossMenu.SetActive(false);
        mainMenu.SetActive(false);
        if (GameStats.firstLoad)
        {
            mainMenu.SetActive(true);
            GameStats.movementAllowed = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && (lossMenuOpen == true))
        {
            ToggleMenu();
            Debug.Log("LossMenu opened");
        }
        if (Input.GetKeyUp(KeyCode.Space) && (GameStats.mainMenuOpen == true))
        {
            mainMenu.SetActive(false);
            GameStats.mainMenuOpen = false;
            GameStats.movementAllowed = true;
        }
        if (mainMenuSwitch < 50)
        {
            mainMenuSwitch++;
        }
        else
        {
            ToggleLogo();
            mainMenuSwitch = 0;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (!GameStats.mainMenuOpen && !lossMenuOpen)
            {
                ToggleMenu();
            }

        }
    }
    public void ToggleMenu()
    {
        string maxLevelString;
        if (!lossMenuOpen)
        {
            lossMenu.SetActive(true);
            GameStats.maxLevel = GameStats.level;
            maxLevelString = GameStats.maxLevel.ToString();
            maxLevelDisplay.text = maxLevelString;
            lossMenuOpen = true;
            playerMovement.ToggleMovement();
        }
        else
        {
            lossMenu.SetActive(false);
            lossMenuOpen = false;
            GameStats.level = 1;
            playerMovement.ReloadScene();
        }
    }
    public void ToggleLogo()
    {
        if (currentLogoBlack)
        {
            logoWhite.SetActive(true);
            logoBlack.SetActive(false);
            currentLogoBlack = false;
        }
        else
        {
            logoWhite.SetActive(false);
            logoBlack.SetActive(true);
            currentLogoBlack = true;
        }
    }
}
