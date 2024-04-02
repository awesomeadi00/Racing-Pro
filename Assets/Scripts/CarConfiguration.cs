using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarConfiguration : MonoBehaviour
{
    [SerializeField] private GameObject carMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material specialMaterial;

    // Start is called before the first frame update
    void Start()
    {
        CarController carController = GameObject.Find("Car").GetComponent<CarController>();

        // If there is a valid car within the scene with a car controller script, then it will access configurations
        if (carController != null)
        {
            carController.ConfigureCar(MainManager.Instance.carType);
        }

        Renderer renderer = carMaterial.GetComponent<Renderer>();

        // If the car is red, then apply the red material
        if (MainManager.Instance.carType == 1)
        {
            renderer.material = redMaterial;
        }

        // If the car is blue, then apply the red material
        else if (MainManager.Instance.carType == 2)
        {
            renderer.material = blueMaterial;
        }

        // Otherwise, we apply the special material. 
        else
        {
            renderer.material = specialMaterial;
        }
    }
}
