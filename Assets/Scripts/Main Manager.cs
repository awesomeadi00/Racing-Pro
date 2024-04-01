using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    //Variables to pass through the menu scene: 
    public int carType;
    public int circuitType;
    public bool unlockSpecial;

    void Awake(){
        if(Instance != null) {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
