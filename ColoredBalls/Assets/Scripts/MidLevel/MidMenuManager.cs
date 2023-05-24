using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MidMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject midMenuPanel;
    void Start()
    {
        midMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        midMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void WhichLevel(string whichLevel)
    {
        Debug.Log(whichLevel);

        SceneManager.LoadScene("GameLevel");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuManager");
    }

}
