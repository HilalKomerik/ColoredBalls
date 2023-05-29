using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject readyImage;

    string whichLevel;
    int �arpanbir;

    void Start()
    {
        if (PlayerPrefs.HasKey("whichLevel"))
        {
            whichLevel = PlayerPrefs.GetString("whichLevel");
        }

        StartCoroutine(ReadyRoutine());

    }


    IEnumerator ReadyRoutine()
    {
        readyImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        readyImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        readyImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        StartGame();
    }

    void StartGame()
    {
        LevelNumber();
    }

    void LevelNumber()
    {
        switch (whichLevel)
        {
            case"one":
                �arpanbir = 2;
                break;
            case "two":
                �arpanbir = 3;
                break;
            case "three":
                �arpanbir = 4;
                break;
            case "four":
                �arpanbir = 5;
                break;
            case "five":
                �arpanbir = 5; // Hareket etsin
                break;
            case "six":
                �arpanbir = 5; // arada kaybolsun 
                break;
            case "seven":
                �arpanbir = 2; 
                break;
            case "eight":
                �arpanbir = 2;
                break;
            case "nine":
                �arpanbir = 2;
                break;
            case "ten":
                �arpanbir = 2;
                break;
        }

        Debug.Log(whichLevel);
    }
}
