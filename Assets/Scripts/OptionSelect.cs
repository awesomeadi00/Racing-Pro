using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class OptionSelect : MonoBehaviour
{
    private int carType;
    private int circuitType;
    [SerializeField] private GameObject circuitSection;
    [SerializeField] private GameObject beginButton;
    [SerializeField] private GameObject unlockText;
    private Button specialCarButton;
    private bool unlockSpecial = false;

    private void Start() {
        specialCarButton = beginButton.GetComponent<Button>();
    }

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
            MainManager.Instance.carType = 2;
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
        SceneManager.LoadScene(1);
    }
}
