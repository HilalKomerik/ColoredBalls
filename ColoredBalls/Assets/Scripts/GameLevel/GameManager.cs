using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject readyImage;

    string whichLevel;
    int çarpanbir;

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
                çarpanbir = 2;
                break;
            case "two":
                çarpanbir = 3;
                break;
            case "three":
                çarpanbir = 4;
                break;
            case "four":
                çarpanbir = 5;
                break;
            case "five":
                çarpanbir = 5; // Hareket etsin
                break;
            case "six":
                çarpanbir = 5; // arada kaybolsun 
                break;
            case "seven":
                çarpanbir = 2; 
                break;
            case "eight":
                çarpanbir = 2;
                break;
            case "nine":
                çarpanbir = 2;
                break;
            case "ten":
                çarpanbir = 2;
                break;
        }

        Debug.Log(whichLevel);
    }
}
