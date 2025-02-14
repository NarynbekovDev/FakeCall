using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RewardedAdComponent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image _statusImage;
    [SerializeField] private Button _clickButton;
    [SerializeField] private TextMeshProUGUI _countText;

    [SerializeField] private GameObject _adsPanel;
    [SerializeField] private GameObject _selectPanel;

    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _unlockSprite;

    [Header("Properties")]
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _textNumber;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private VideoClip _videoClip;

    [SerializeField] private bool _isFree = false;
    [SerializeField] private int _neededWatchCount = 4;

    public Action<Contact> onClick;

    private int _currentWatchCount = 0; 

    public bool IsOpen { get; private set; }
    public bool IsEnable { get; private set; }

    public void Init()
    {
        _clickButton.onClick.AddListener(Select);

        if (_isFree)
        {
            IsOpen = true;
        }
        else
        {
            IsOpen = PlayerPrefs.HasKey("contact" + _name);
        }
    }


    public void UpdateContact()
    {
        string data = PlayerPrefs.GetString("current" + _name, "disable");


        if (data != "disable")
        {
            onClick?.Invoke(new Contact(_name, _icon, _textNumber, _audioClip, _videoClip));

            PlayerPrefs.SetString("current" + _name, "select");
            PlayerPrefs.Save();
        }
        
        SetActive(data != "disable");
    }

    public void Hide()
    {
        SetActive(false);
        PlayerPrefs.SetString("current" + _name, "disable");
        PlayerPrefs.Save();
    }

    public void SetActive(bool enable)
    {
        _adsPanel.SetActive(!IsOpen);
        _selectPanel.SetActive(IsOpen);

        _statusImage.sprite = enable ? _selectedSprite : _unlockSprite;

        _countText.text = $"{_currentWatchCount}/{_neededWatchCount}";

        IsEnable = enable;
    }
    private void Select()
    {
        if (IsOpen)
        {
            onClick?.Invoke(new Contact(_name, _icon, _textNumber, _audioClip, _videoClip));

            SetActive(true);

            // Сохранить айдишку
            PlayerPrefs.SetString("current" + _name, "select");
            PlayerPrefs.Save();

        }
        else
        {
            LaunchAd();
        }
    }
    private void LaunchAd()
    {
        AdsManager.Instance.onRewardedAdFinish.AddListener(OnFinishAd);

        AdsManager.Instance.ShowRewardedAd();
    }

    private void OnFinishAd()
    {
        _currentWatchCount++;
        IsOpen = _currentWatchCount >= _neededWatchCount;

        UpdateItem();
    }

    private void UpdateItem()
    {
        if (IsOpen)
        {
            PlayerPrefs.SetString("contact" + _name, "open");
            PlayerPrefs.Save();
            Select();
        }
        else
        {
            _countText.text = $"{_currentWatchCount}/{_neededWatchCount}";
        }
    }
}
