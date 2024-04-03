using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public int currentlapNumber = 0;
    public bool raceFinish = false;
    private bool lapCompleted = false;

    private float lapStartTime;
    private float raceStartTime;
    private List<float> lapTimes = new List<float>();

    public TextMeshProUGUI currentlapNumberText;

    public TextMeshProUGUI lapMinuteText;
    public TextMeshProUGUI lapSecondText;
    public TextMeshProUGUI lapMillisecondText;

    public TextMeshProUGUI raceMinuteText;
    public TextMeshProUGUI raceSecondText;
    public TextMeshProUGUI raceMillisecondText;


    void Start()
    {
        currentlapNumberText.text = "0";

        lapMinuteText.text = "00";
        lapSecondText.text = "00";
        lapMillisecondText.text = "00";

        raceMinuteText.text = "00";
        raceSecondText.text = "00";
        raceMillisecondText.text = "00";

        raceStartTime = Time.time;
        lapStartTime = Time.time;
    }

    void Update()
    {
        if (!raceFinish && !lapCompleted)
        {
            UpdateTimer(Time.time - lapStartTime, lapMinuteText, lapSecondText, lapMillisecondText, true);
            UpdateTimer(Time.time - raceStartTime, raceMinuteText, raceSecondText, raceMillisecondText, false);
        }
    }

    private void UpdateTimer(float elapsedTime, TextMeshProUGUI minuteText, TextMeshProUGUI secondText, TextMeshProUGUI millisecondText, bool isLapTimer)
    {
        int minutes = (int)(elapsedTime / 60);
        float seconds = elapsedTime % 60;
        string formattedSeconds = seconds.ToString("00.00");
        string[] splitSeconds = formattedSeconds.Split('.');

        minuteText.text = minutes.ToString("00");
        secondText.text = splitSeconds[0]; // Whole seconds
        millisecondText.text = splitSeconds[1];
    }

    public void IncrementLap() {
        currentlapNumber += 1;
        currentlapNumberText.text = currentlapNumber.ToString("0");

        if (currentlapNumber == 3)
        {
            raceFinish = true;
        }

        else
        {
            lapCompleted = true;
            StartCoroutine(ResetLapTimer());   // Reset lap timer visuals in the next frame

        }
    }

    IEnumerator ResetLapTimer()
    {
        yield return null; // Wait for the next frame

        lapMinuteText.text = "00";
        lapSecondText.text = "00";
        lapMillisecondText.text = "00";
        lapStartTime = Time.time;
        lapCompleted = false; 
    }
}
