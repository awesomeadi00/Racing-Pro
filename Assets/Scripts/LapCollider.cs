using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCollider : MonoBehaviour
{
    private HUDManager hudManager;

    // Start is called before the first frame update
    void Start()
    {
        hudManager = GameObject.FindObjectOfType<HUDManager>();
        if(hudManager == null) {
            Debug.LogError("HUDManager not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hudManager.IncrementLap();
        }
    }
}
