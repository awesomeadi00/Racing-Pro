using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class OptionSelect : MonoBehaviour
{
    [SerializeField] private GameObject circuitSection;
    [SerializeField] private GameObject beginButton;
    [SerializeField] private GameObject unlockText;

    public void RedCar() {
        MainManager.Instance.carType = 1;
        circuitSection.SetActive(true);
    }

    public void BlueCar() {
        MainManager.Instance.carType = 2;
        circuitSection.SetActive(true);
    }

    public void SpecialCar() {
        if(MainManager.Instance.unlockSpecial) {
            MainManager.Instance.carType = 3;
            unlockText.SetActive(false);
            circuitSection.SetActive(true);
        }

        else {
            unlockText.SetActive(true);
        }
    }

    public void Circuit1() {
        MainManager.Instance.circuitType = 1;
        beginButton.SetActive(true);
    }

    public void Circuit2()
    {
        MainManager.Instance.circuitType = 2;
        beginButton.SetActive(true);
    }

    public void BeginGame() {
        if(MainManager.Instance.circuitType == 1) {
            SceneManager.LoadScene(1);
        }

        else {
            SceneManager.LoadScene(2);
        }
    }
}
