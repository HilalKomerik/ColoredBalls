using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject readyImage;
    void Start()
    {
        if (PlayerPrefs.HasKey("whichLevel"))
        {
           // Debug.Log(PlayerPrefs.GetString("whichLevel"));
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
        Debug.Log("Oyun baþladý");
    }
}
