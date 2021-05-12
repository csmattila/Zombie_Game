using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public int highScore;
    public GunHandler gunhandler;
    public MapHandler mapHandler;
    string mapToUse;
    string gunToUse;
    public GameObject townMap;
    public GameObject wildernessMap;
    public GameObject ruinsMap;
    public GameObject mainMenu;
    public GameObject gameUI;
    public GameObject pauseMenu;
    public TextMeshProUGUI highScoreText;
    public GunManager townGunScript;
    public GunManager wildernessGunScript;
    public GunManager ruinsGunScript;
    public Canvas canvas;
    bool paused;
    

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    private void Awake()
    {
        Time.timeScale = 0f;
        highScore = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {

                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }

        
    }

    public void pauseGame()
    {
        paused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        paused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(false);
    }

    public void enterMainMenu()
    {
        
        SceneManager.LoadScene("ZombieMain");

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startButtonPressed()
    {
        mapToUse = mapHandler.getSelectedMap();
        gunToUse = gunhandler.getSelectedGun();
        Debug.Log("The gun to use is " + gunToUse + " map is " + mapToUse);

        if(mapToUse == "Town")
        {
            townMap.SetActive(true);
            wildernessMap.SetActive(false);
            ruinsMap.SetActive(false);
            gameUI.SetActive(true);
            mainMenu.SetActive(false);
            townGunScript.setWeapon(gunToUse);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else if(mapToUse == "Wilderness")
        {
            townMap.SetActive(false);
            wildernessMap.SetActive(true);
            ruinsMap.SetActive(false);
            gameUI.SetActive(true);
            mainMenu.SetActive(false);
            wildernessGunScript.setWeapon(gunToUse);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else if (mapToUse == "Ruins")
        {
            townMap.SetActive(false);
            wildernessMap.SetActive(false);
            ruinsMap.SetActive(true);
            gameUI.SetActive(true);
            mainMenu.SetActive(false);
            ruinsGunScript.setWeapon(gunToUse);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

        

    }
}
