using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text TimeText;

    int remainingTime ;

    bool countTime ;
    void Start()
    {
        remainingTime = 15;
        countTime = true;
        StartCoroutine(TimeTimerRoutine());
    }

    IEnumerator TimeTimerRoutine()
    {
        while (countTime)
        {
            yield return new WaitForSeconds(1f);

            if (remainingTime<10)
            {
                TimeText.text = "0" + remainingTime.ToString();

                TimeText.color = Color.red;
            }
            else
            {
                TimeText.text = remainingTime.ToString();

            }

            if (remainingTime<=0)
            {
                countTime = false;
                TimeText.text = "0";
            }
            remainingTime--;
        }
    }

}
