using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControlManager : MonoBehaviour
{
    private void Start()
    {
        TurnSoundOn();
    }

    public void TurnSoundOn()
    {
        PlayerPrefs.SetInt("soundStatus", 1);
    }

    public void ShutSound()
    {
        PlayerPrefs.SetInt("soundStatus", 0);
    }
}
