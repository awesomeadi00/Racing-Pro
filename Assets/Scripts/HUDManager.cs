using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class HUDManager : MonoBehaviour
{
    public int currentlapNumber = 0;
    public bool raceFinish = false;
    private bool lapCompleted = false;
    private bool raceStarted = false;

    private float lapStartTime;
    private float raceStartTime;
    
    private float raceEndTime;
    public float RaceDuration
    {
        get
        {
            // If the race hasn't finished, calculate duration up to now; otherwise, use end time
            return raceFinish ? raceEndTime - raceStartTime : Time.time - raceStartTime;
        }
    }

    private List<float> lapTimes = new List<float>();
    public List<float> LapTimes
    {
        get { return new List<float>(lapTimes); }
    }

    public TextMeshProUGUI currentlapNumberText;

    public TextMeshProUGUI lapMinuteText;
    public TextMeshProUGUI lapSecondText;
    public TextMeshProUGUI lapMillisecondText;

    public TextMeshProUGUI raceMinuteText;
    public TextMeshProUGUI raceSecondText;
    public TextMeshProUGUI raceMillisecondText;

    private CarController carController;
    private FollowPlayer followCamera;
    public GameObject raceEndScreen;
    public GameObject raceFinishManager;


    void Start()
    {
        carController = FindObjectOfType<CarController>(); 
        followCamera = FindObjectOfType<FollowPlayer>();

        currentlapNumberText.text = "0";

        lapMinuteText.text = "00";
        lapSecondText.text = "00";
        lapMillisecondText.text = "00";

        raceMinuteText.text = "00";
        raceSecondText.text = "00";
        raceMillisecondText.text = "00";
    }

    void Update()
    {
        if (!raceFinish && !lapCompleted && raceStarted)
        {
            UpdateTimer(Time.time - lapStartTime, lapMinuteText, lapSecondText, lapMillisecondText, true);
            UpdateTimer(Time.time - raceStartTime, raceMinuteText, raceSecondText, raceMillisecondText, false);
        }
    }

    public void StartRace()
    {
        raceStartTime = Time.time;
        lapStartTime = Time.time;
        raceFinish = false; 
        raceStarted = true;
    }

    private void UpdateTimer(float elapsedTime, TextMeshProUGUI minuteText, TextMeshProUGUI secondText, TextMeshProUGUI millisecondText, bool isLapTimer)
    {
        int minutes = (int)(elapsedTime / 60);
        float seconds = elapsedTime % 60;
        string formattedSeconds = seconds.ToString("00.00");
        string[] splitSeconds = formattedSeconds.Split('.');

        minuteText.text = minutes.ToString("00");
        secondText.text = splitSeconds[0];
        millisecondText.text = splitSeconds[1];
    }

    public void IncrementLap()
    {
        if (currentlapNumber > 0) 
        {
            float lapTime = Time.time - lapStartTime;
            lapTimes.Add(lapTime);
        }

        currentlapNumber += 1;
        currentlapNumberText.text = currentlapNumber.ToString("0");

        if (currentlapNumber == 3)
        {   
            RaceFinish();
        }

        // Reset for next lap or at race finish
        lapCompleted = true;
        StartCoroutine(ResetLapTimer());
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

    private void RaceFinish() {
        raceEndScreen.SetActive(true);
        raceFinishManager.SetActive(true);
        raceFinish = true;
        raceEndTime = Time.time; 
        followCamera.enabled = false;
        carController.enabled = false;
    }
}
