using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject lossMenu;
    public float score;
    public bool lossMenuOpen;
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        lossMenuOpen = false;
        lossMenu.SetActive(false);
        score = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            toggleMenu();
            Debug.Log("LossMenu openen");
        }
    }
    public void toggleMenu()
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
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
