using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanksForCalling : MonoBehaviour
{
    [SerializeField] private GameObject thanksForCallingPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject popupChoosePanel;

    public void IntertitialAd()
    {
        AdsManager.Instance.ShowInterstitialAd();
    }

    public void BackButton()
    {
        thanksForCallingPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void SettingButton()
    {
        thanksForCallingPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CallAgainButton()
    {
        popupChoosePanel.SetActive(true);
    }
}
