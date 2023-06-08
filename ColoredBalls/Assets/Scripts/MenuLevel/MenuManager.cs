using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private GameObject SoundPanel;

    bool IsSoundPanelOpen;
    void Start()
    {
        IsSoundPanelOpen = false;
        SoundPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, -66, 0);

        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void PlayButton()
    {
        if (PlayerPrefs.GetInt("soundStatus")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MidLevel");
    }

    public void SettingsButton()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        if (!IsSoundPanelOpen)
        {
            SoundPanel.GetComponent<RectTransform>().DOLocalMoveX(131, 0.5f);
            IsSoundPanelOpen = true;
        }
        else
        {
            SoundPanel.GetComponent<RectTransform>().DOLocalMoveX(0, 0.5f);
            IsSoundPanelOpen = false;
        }
    }

    public void ExitButton()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        Application.Quit();
    }
}
