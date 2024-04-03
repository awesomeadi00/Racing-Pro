using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceFinishStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestLapTime;
    [SerializeField] private TextMeshProUGUI totalRaceTime;
    [SerializeField] private TextMeshProUGUI ratingValue;
    [SerializeField] private HUDManager hudManager;
    private AudioSource raceFinishAudioSource;
    public AudioClip completedAudioClip;

    private void OnEnable()
    {
        raceFinishAudioSource = GetComponent<AudioSource>();
        StartCoroutine(DisplayRaceStatistics());
    }

    IEnumerator DisplayRaceStatistics()
    {
        // Wait for a frame to ensure HUDManager has finished its work
        yield return null;

        raceFinishAudioSource.PlayOneShot(completedAudioClip);

        // Display the fastest lap time
        if (hudManager.LapTimes.Count > 0)
        {
            float fastestLap = Mathf.Min(hudManager.LapTimes.ToArray());
            bestLapTime.text = FormatTime(fastestLap);
            yield return new WaitForSeconds(2f);
        }

        // Display the total race time
        float raceDuration = hudManager.RaceDuration;
        totalRaceTime.text = FormatTime(raceDuration);
        yield return new WaitForSeconds(2f);

        // Calculate and display the rating
        ratingValue.text = CalculateRating(raceDuration);
    }

    string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int milliseconds = (int)((time * 100) % 1000);
        return $"{minutes:00} : {seconds:00} : {milliseconds:00}";
    }

    string CalculateRating(float totalTime)
    {
        if (totalTime <= 240) return "5/5";
        if (totalTime <= 270) return "4/5";
        if (totalTime <= 300) return "3/5";
        if (totalTime <= 330) return "2/5";
        if (totalTime <= 360) return "1/5";
        return "0/5";
    }
}
