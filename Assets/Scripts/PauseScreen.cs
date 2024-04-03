using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pausedScreen;
    private bool paused = false;
    private HUDManager hudHelper;
    private InitialCountDown countDown;

    private void Start() {
        hudHelper = GameObject.FindObjectOfType<HUDManager>();
        countDown = gameObject.GetComponent<InitialCountDown>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !hudHelper.raceFinish && countDown.countDownComplete)
        {
            PauseGame();
        }
    }

    //This function will be called to pause the game. 
    public void PauseGame()
    {
        //This will pause the game and change the timescale to 0, meaning that time will not move and therefore nothing will move. 
        if (!paused)
        {
            paused = true;
            pausedScreen.SetActive(true);
            Time.timeScale = 0;
        }

        //This will unpause the game and change the timescale back to 1, meaning that time will flow regularly as before. 
        else
        {
            paused = false;
            pausedScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //In this function, when we press the restart button, it will reload the Scene which is Prototype 5, meaning it will restart the script.
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //This function will simply reload the entire previous Active Scene from the beginning. 
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
