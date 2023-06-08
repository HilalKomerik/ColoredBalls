using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MidMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject midMenuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;
    void Start()
    {
        if (midMenuPanel != null)
        {
            midMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
            midMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);    

        }
    }

    public void WhichLevel(string whichLevel)
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        PlayerPrefs.SetString("whichLevel", whichLevel);
        SceneManager.LoadScene("GameLevel");
    }

    public void BackButton()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MenuManager");
    }

}
