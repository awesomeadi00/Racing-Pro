using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class InitialCountDown : MonoBehaviour
{
    public int countDownTime;
    public TextMeshProUGUI countDownDisplayText;
    public CarController carController; 
    public HUDManager hudManager;
    private AudioSource countdownAudioSource;
    public AudioClip countDownClip;

    // Start is called before the first frame update
    void Start()
    {
        countdownAudioSource = GetComponent<AudioSource>();
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart() {
        carController.enabled = false;
        countdownAudioSource.PlayOneShot(countDownClip);

        while(countDownTime > 0) {
            countDownDisplayText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }

        countDownDisplayText.text = "GO!";

        carController.enabled = true;

        if (hudManager != null) {
            hudManager.StartRace();
        }

        yield return new WaitForSeconds(1f);
        countDownDisplayText.gameObject.SetActive(false);
    }
}
