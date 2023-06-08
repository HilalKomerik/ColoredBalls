using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultsManager : MonoBehaviour
{
    [SerializeField]
    private Image resultsImage;

    [SerializeField]
    private Text trueText, falseText, puanText;

    [SerializeField]
    private GameObject PlayAgainButton, BackMenuButton;




    float durationTimer;
    bool openImage;



    private void Start()
    {
        durationTimer = 0;
        openImage = true;

        trueText.text = "";
        falseText.text = "";
        puanText.text = "";

        PlayAgainButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        BackMenuButton.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(PictureRoutine());
    }

    IEnumerator PictureRoutine()
    {
        while (openImage)
        {
            durationTimer += .15f;
            resultsImage.fillAmount = durationTimer;

            yield return new WaitForSeconds(0.1f);

            if (durationTimer>=1)
            {
                durationTimer = 1;
                openImage = false;

                trueText.text = "10 dogru";
                falseText.text = "10 dogru";
                puanText.text = "10 dogru";


                PlayAgainButton.GetComponent<RectTransform>().DOScale(1, 2f);
                BackMenuButton.GetComponent<RectTransform>().DOScale(1, 2f);

            }
        }
    }


}
