using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    void Start()
    {
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("MidLevel");
    }

    public void SettingsButton()
    {
        //Daha sonra yapacaðým
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
