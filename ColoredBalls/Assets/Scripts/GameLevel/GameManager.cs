using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("whichLevel"))
        {
            Debug.Log(PlayerPrefs.GetString("whichLevel"));
        }
        
    }
}
