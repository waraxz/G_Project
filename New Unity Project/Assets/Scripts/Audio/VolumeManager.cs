using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    public VolumeController[] vcObjects;


    public float MaxVolumeLevel = 1.0f;
    public float currentVolumeLevel;


    // Start is called before the first frame update
    void Start()
    {
        vcObjects = FindObjectsOfType<VolumeController>();

        if (currentVolumeLevel > MaxVolumeLevel)
        {
            currentVolumeLevel = MaxVolumeLevel;
        }

        for (int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].SetAudioLevel(currentVolumeLevel);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
