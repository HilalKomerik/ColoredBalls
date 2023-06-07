using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject readyImage;

    [SerializeField]
    private Text questionText, firstResultText, secondResultText, thirdResultText;

    [SerializeField]
    private Text trueText, falseText, pointsText;

    string whichLevel;

    int firstMultiplier;
    int secondMultiplier;

    int correctResult; // Doðru sonuç

    int firstFalseResult; // birinci yanlýþ
    int secondFalseResult; //ikinci yanlýþ 


    int falseNumber, trueNumber, totalPoints;
    void Start()
    {
        falseNumber = 0;
        trueNumber = 0;
        totalPoints = 0;

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
        PrintQuestion();
    }

    void LevelNumber()
    {
        switch (whichLevel)
        {
            case"one":
                firstMultiplier = 1;
                break;
            case "two":
                firstMultiplier = 2;
                break;
            case "three":
                firstMultiplier = 3;
                break;
            case "four":
                firstMultiplier = 4;
                break;
            case "five":
                firstMultiplier = 5;
                break;
            case "six":
                firstMultiplier = 6;
                break;
            case "seven":
                firstMultiplier = 7; 
                break;
            case "eight":
                firstMultiplier = 8;
                break;
            case "nine":
                firstMultiplier = 9;
                break;
            case "ten":
                firstMultiplier = 10;
                break;
        }

        Debug.Log(firstMultiplier);
    }

    void PrintQuestion()
    {
        LevelNumber();

        secondMultiplier = Random.Range(2, 11);

        int randomValue = Random.Range(1, 100);
        if (randomValue<=50)
        {
            questionText.text = firstMultiplier.ToString() + "x" + secondMultiplier.ToString();
        }
        else
        {
            questionText.text = secondMultiplier.ToString() + "x" + firstMultiplier.ToString();
        }

        correctResult = firstMultiplier * secondMultiplier;

        Results();
    }


    void Results()
    {

        firstFalseResult = correctResult + Random.Range(1, 10);

        if (correctResult>10)
        {
            secondFalseResult = correctResult - Random.Range(2, 8);
        }
        else
        {
            secondFalseResult = Mathf.Abs(correctResult - Random.Range(2, 8));
        }



        int randomValue = Random.Range(1, 100);

        if (randomValue <=33)
        {
            firstResultText.text = correctResult.ToString();
            secondResultText.text = firstFalseResult.ToString();
            thirdResultText.text = secondFalseResult.ToString();
        }
        else if (randomValue<=66)
        {
            secondResultText.text = correctResult.ToString();
            firstResultText.text = firstFalseResult.ToString();
            thirdResultText.text = secondFalseResult.ToString();
        }
        else
        {
            thirdResultText.text = correctResult.ToString();
            firstResultText.text = secondFalseResult.ToString();
            secondResultText.text = firstFalseResult.ToString();
        }


    }

    public void CheckResult(int textResult)
    {
        if (textResult == correctResult)
        {
            trueNumber++;
            totalPoints += 20;
        }
        else
        {
            falseNumber++;
        }

        trueText.text = trueNumber.ToString() + " DOGRU";
        falseText.text = falseNumber.ToString() + " YANLIS";
        pointsText.text = totalPoints.ToString() + " PUAN";

        Results();
    }
    
}
