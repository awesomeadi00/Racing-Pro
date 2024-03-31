using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    //These are variables for the buttons: 
    [SerializeField] private Button startButton;
    [SerializeField] private Button instructionsButton;
    [SerializeField] private Button exitButton;

    //These are variables for the screens on the canvas
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject instructionsScreen;
    [SerializeField] private GameObject selectScreen;

    private AudioSource menuAudio;
    [SerializeField] private AudioClip buttonClick;

    //Variable to check which screen the user is on, 0 = title screen, 1 = instruction screen
    private int gameScreen;

    void Start() {
        gameScreen = 0;
        menuAudio = GetComponent<AudioSource>();
    }

    //This function will be called to start the Main Scene
    public void StartGame() {
        menuAudio.PlayOneShot(buttonClick, 2.0f);
        titleScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        selectScreen.SetActive(true);
        gameScreen = 2;
    }

    //This function will activate the instructions screen when the instructions button is pressed
    public void ViewInstructionsScreen() {
        menuAudio.PlayOneShot(buttonClick, 2.0f);
        titleScreen.SetActive(false);
        instructionsScreen.SetActive(true);
        gameScreen = 1;
    }

    //This function will allow the user to quit the game. 
    public void ExitGame() {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();  
    #else
        Application.Quit();  
    #endif
    }

    //This function will allow the user to navigate back to the Menu.
    public void BackButton() {
        menuAudio.PlayOneShot(buttonClick, 2.0f);
        //If the user is on the instruction screen, then make it false and return to title screen state
        if(gameScreen == 1) {
            instructionsScreen.SetActive(false);
            titleScreen.SetActive(true);
            gameScreen = 0;
        }

        if (gameScreen == 2) {
            selectScreen.SetActive(false);
            titleScreen.SetActive(true);
            gameScreen = 0;
        }
    }

    public void LetsRace()
    {
        menuAudio.PlayOneShot(buttonClick, 2.0f);
        SceneManager.LoadScene(1);
    }
}
