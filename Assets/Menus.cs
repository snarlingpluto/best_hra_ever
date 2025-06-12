using UnityEngine;
using UnityEngine.UIElements;

public class Menus : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject lossMenu;
    public GameObject mainMenu;
    public GameObject logoWhite;
    public GameObject logoBlack;
    public float score;
    public float mainMenuSwitch = 0;
    public bool currentLogoBlack = true;
    public bool lossMenuOpen;
    public bool mainMenuOpen = true;
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        lossMenuOpen = false;
        lossMenu.SetActive(false);
        score = 0;
        mainMenu.SetActive(false);
        if (GameStats.firstLoad)
        {
            mainMenu.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && (lossMenuOpen == true))
        {
            ToggleMenu();
            Debug.Log("LossMenu opened");
        }
        if (Input.GetKeyUp(KeyCode.Space) && (mainMenuOpen == true))
        {
            mainMenu.SetActive(false);
            GameStats.mainMenuOpen = false;
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
    }
    public void ToggleMenu()
    {
        if (!lossMenuOpen)
        {
            lossMenu.SetActive(true);
            lossMenuOpen = true;
        }
        else
        {
            lossMenu.SetActive(false);
            lossMenuOpen = false;
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
