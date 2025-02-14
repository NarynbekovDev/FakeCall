using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Home
    [Header("HomeStartButtons")]
    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject startButtonHome;
    [SerializeField] private GameObject exitButtonHome;

    // Menu
    [Header("MenuButtons")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject backButtonMenu;
    [SerializeField] private GameObject settingButtonMenu;
    [SerializeField] private GameObject shareButtonMenu;
    [SerializeField] private GameObject rateUsButtonMenu;
    [SerializeField] private GameObject charactersButtonMenu;
    [SerializeField] private GameObject chatButtonMenu;
    [SerializeField] private GameObject callButtonMenu;
    [SerializeField] private GameObject vidoeCallButtonMenu;
    [SerializeField] private GameObject liveButtonMenu;
    [SerializeField] private GameObject playGamesButtonMenu;

    // Chat 
    [Header("ChatButtons")]
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private GameObject backButtonChat;
    [SerializeField] private GameObject audioCallButtonChat;
    [SerializeField] private GameObject videoCallButtonChat;
    [SerializeField] private GameObject gifrButtonChat;

    // Audio Call
    [Header("AudioCallButtons")]
    [SerializeField] private GameObject audioCallPanel;
    [SerializeField] private GameObject pickUpCallButtonAudio;
    [SerializeField] private GameObject dontPickUpCallButtonAudio;

    // Pick Up Audio Call
    [Header("PickUpAudioCallButton")]
    [SerializeField] private GameObject pickUpAudioCallPanel;
    [SerializeField] private GameObject turnOffTheCallButtonPickUpAudio;


    // Video
    [Header("VideoCallButtons")]
    [SerializeField] private GameObject videoCallPanel;
    [SerializeField] private GameObject pickUpVideoCallButtonVideo;
    [SerializeField] private GameObject dontPickUpVideoCallButtonVideo;

    [Header("PickUpVideoCallButton")]
    [SerializeField] private GameObject pickUpVideoCallPanel;
    [SerializeField] private GameObject turnOffButtonPickUpVideo;


    // Live 
    [Header("LiveButtons")]
    [SerializeField] private GameObject livePanel;
    [SerializeField] private GameObject turnOffButtonLive;
    [SerializeField] private GameObject moreGamesButtonLive;


    // Contacts
    [Header("ContactsButton")]
    [SerializeField] private GameObject contactsPanel;
    [SerializeField] private GameObject backButtonContacts;

    // PopupAdd
    [Header("PopupAdd")]
    [SerializeField] private GameObject popupAddPanel;
    [SerializeField] private GameObject closePopupAdd;
    [SerializeField] private GameObject watchAdButtonPopupAdd;

    // Settings 
    [Header("SettingsButton")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject backButtonSettins;
    [SerializeField] private GameObject licenseButton;
    [SerializeField] private GameObject privacyPolicyButton;
    [SerializeField] private GameObject rateUsButton;
    [SerializeField] private GameObject shareItButton;
    [SerializeField] private GameObject moreAppsButton;
    [SerializeField] private GameObject playGamesButton;


    // ExitPanel
    [Header("ExitPanel")]
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject backButtonExitPanel;
    [SerializeField] private GameObject playGamesExitPanel;
    [SerializeField] private GameObject exitButtonExitPanel;


    // LoadingPanel
    [Header("LoadingPanel")]
    [SerializeField] private GameObject loadingPanel;

    // ThanksPanel
    [Header("ThanksForYouButtons")]
    [SerializeField] private GameObject thanksForYouPanel;
    [SerializeField] private GameObject backButtonThanks;
    [SerializeField] private GameObject settingsButtonThanks;

    [SerializeField] private GameObject maxIconButton;
    [SerializeField] private GameObject rockyIconButton;
    [SerializeField] private GameObject charlieIconButton;
    [SerializeField] private GameObject miloIconButton;



    // PopupChoose
    [Header("PopupChooseButtons")]
    [SerializeField] private GameObject popupChoosePanel;
    [SerializeField] private GameObject chatButtonPopup;
    [SerializeField] private GameObject callButtonPopup;
    [SerializeField] private GameObject videoCallButtonPopup;
    [SerializeField] private GameObject liveButtonPopup;


    private AdsManager _adsManager;


    private void Awake()
    {
        _adsManager = FindObjectOfType<AdsManager>().GetComponent<AdsManager>();
    }

    public void IntertitialAd()
    {
        AdsManager.Instance.ShowInterstitialAd();
    }

    public void StartHome()
    {
        homePanel.SetActive(false);
        menuPanel.SetActive(true);

        IntertitialAd();
    }

    public void ExitHome()
    {
        homePanel.SetActive(false);
        exitPanel.SetActive(true);

        IntertitialAd();
    }

    public void BackMenu()
    {
        menuPanel.SetActive(false);
        homePanel.SetActive(true);

        IntertitialAd();
    }

    public void SettingsMenu()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);

        IntertitialAd();
    }

    public void Share()
    {
        // Here we need open the panel where we can share something
    }

    public void RateUs()
    {
        // Open maybe Play Market
    }

    public void CharactersMenu()
    {
        menuPanel.SetActive(false);
        contactsPanel.SetActive(true);

        IntertitialAd();
    }

    public void ChatMenu()
    {
        menuPanel.SetActive(false);
        chatPanel.SetActive(true);

        IntertitialAd();
    }

    public void CallMenu()
    {
        menuPanel.SetActive(false);
        audioCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void VideoCallMenu()
    {
        menuPanel.SetActive(false);
        videoCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void LiveMenu() 
    {
        menuPanel.SetActive(false);
        livePanel.SetActive(true);

        IntertitialAd();
    }

    public void PlayGames()
    {
        // Open URL link
    }

    public void BackChat()
    {
        chatPanel.SetActive(false);
        menuPanel.SetActive(true);

        IntertitialAd();
    }

    public void VideoCallChat()
    {
        chatPanel.SetActive(false);
        videoCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void TurnOffTheVideoCall()
    {
        pickUpVideoCallPanel.SetActive(false);
        loadingPanel.SetActive(true);

        IntertitialAd();
    }

    public void AudioCallChat()
    {
        chatPanel.SetActive(false);
        audioCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void GiftButtonChat()
    {
        chatPanel.SetActive(false);
        contactsPanel.SetActive(true);

        IntertitialAd();
    }

    public void PickUpAudioCall()
    {
        audioCallPanel.SetActive(false);
        pickUpAudioCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void DontPickUpAudioCall()
    {
        audioCallPanel.SetActive(false);
        contactsPanel.SetActive(true);

        IntertitialAd();
    }

    public void TurnOffTheAudioCall()
    {
        pickUpAudioCallPanel.SetActive(false);
        loadingPanel.SetActive(true);

        IntertitialAd();
    }

    public void CharactersPickUpAudioCall()
    {
        pickUpAudioCallPanel.SetActive(false);
        chatPanel.SetActive(true);
    }

    public void VideoCallPickUpAudioCall()
    {
        pickUpAudioCallPanel.SetActive(false);
        videoCallPanel.SetActive(true);
    }

    public void ChatPickUpAudioCall()
    {
        pickUpAudioCallPanel.SetActive(false);
        chatPanel.SetActive(true);
    }

    public void PickUpVideoCall()
    {
        videoCallPanel.SetActive(false);
        pickUpVideoCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void DontPickUpVideoCall()
    {
        pickUpVideoCallPanel.SetActive(false);
        contactsPanel.SetActive(true);

        IntertitialAd();
    }

    public void TurnOffTheLive()
    {
        turnOffButtonLive.SetActive(false);
        loadingPanel.SetActive(true);

        IntertitialAd();
    }

    public void MoveGameLive()
    {
        // Open the link
    }

    public void BackContacts()
    {
        contactsPanel.SetActive(false);
        menuPanel.SetActive(true);

        IntertitialAd();
    }

    public void ClosePopupAd()
    {
        popupAddPanel.SetActive(false);
    }

    public void WatchAdPopup()
    {
        // Need open Revard
        _adsManager.ShowRewardedAd();
    }

    public void BackSettings()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);

        IntertitialAd();
    }

    public void LicenseButton()
    {
        // Open strings.xml
    }

    public void PrivacyPolicyButton()
    {
        // Open strings.xml
    }

    public void MoreApps()
    {
        // при клике more apps открывается страница разработчика в google play
    }

    public void BackButtonExitPanel()
    {

        homePanel.SetActive(true);
        exitPanel.SetActive(false);

        IntertitialAd();
    }

    public void ExitGame()
    {
        // Exit game
    }

    public void BackThanks()
    {
        thanksForYouPanel.SetActive(false);
        menuPanel.SetActive(true);

        IntertitialAd();
    }

    public void SettingsThanks()
    {
        thanksForYouPanel.SetActive(false);
        settingsPanel.SetActive(true);

        IntertitialAd();
    }

    public void CharactersButton()
    {
        thanksForYouPanel.SetActive(false);
        contactsPanel.SetActive(true);
    }

    public void CallAgainThanks()
    {
        popupChoosePanel.SetActive(true);
    }

    public void ChatPopupChoose()
    {
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
        chatPanel.SetActive(true);

        IntertitialAd();
    }

    public void CallPopupChoose()
    {
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
        audioCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void VideoCallPopupChoose()
    {
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
        videoCallPanel.SetActive(true);

        IntertitialAd();
    }

    public void LivePopupChoose()
    {
        thanksForYouPanel.SetActive(false);
        popupChoosePanel.SetActive(false);
        livePanel.SetActive(true);

        IntertitialAd();
    }
}
