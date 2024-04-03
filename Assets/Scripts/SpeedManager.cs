using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SpeedManager : MonoBehaviour
{
    public float vehicleSpeed;
    public GameObject needle;
    private float startPosition = 220f, endPosition = -41f;
    private float desiredPosition;
    private CarController vehicleController;

    // Start is called before the first frame update
    void Start()
    {
        vehicleController = GameObject.FindObjectOfType<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        // This line should provide the speed of the vehicle to the vehicleSpeed variable, but how to find...
        vehicleSpeed = vehicleController.CurrentSpeed;
        updateNeedle();
    }

    public void updateNeedle() {
        desiredPosition = startPosition - endPosition;
        float temp = vehicleSpeed / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));
    }
}
