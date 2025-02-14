using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChoose : MonoBehaviour
{
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private GameObject callPanel;
    [SerializeField] private GameObject videoCallPanel;
    [SerializeField] private GameObject livePanel;
    [SerializeField] private GameObject thanksForYouPanel;
    [SerializeField] private GameObject popupChoosePanel;


    public void IntertitialAd()
    {
        AdsManager.Instance.ShowInterstitialAd();
    }

    public void ChatButton()
    {
        chatPanel.SetActive(true);
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
    }

    public void CallButton()
    {
        callPanel.SetActive(true);
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
    }

    public void VideoCallButton()
    {
        videoCallPanel.SetActive(true);
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
    }

    public void LiveButton()
    {
        livePanel.SetActive(true);
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
    }
}
