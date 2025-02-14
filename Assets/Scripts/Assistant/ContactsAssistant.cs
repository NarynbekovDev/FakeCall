using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ContactsAssistant : MonoBehaviour
{
    public static ContactsAssistant Instance;


    [SerializeField] private RewardedAdComponent[] _contacts;

    [Header("Menu")]
    [SerializeField] private Image contactIconMenuPanel;
    [SerializeField] private TextMeshProUGUI contactMenuNameText;

    [Header("Chat")]
    [SerializeField] private Image contactIconChat;
    [SerializeField] private TextMeshProUGUI contactChatNameTextChat;

    [Header("Call")]
    [SerializeField] private Image contactIconCall;
    [SerializeField] private TextMeshProUGUI contactCallNameText;
    [SerializeField] private TextMeshProUGUI contactCallNumberText;
    [SerializeField] public AudioClip contactCallAudioClip;

    [Header("PickUpCall")]
    [SerializeField] private Image contactIconPickUpCall;
    [SerializeField] private TextMeshProUGUI contactPickUpCallNameText;
    [SerializeField] private TextMeshProUGUI contactPickUpCallNumberText;

    [Header("VideoCall")]
    [SerializeField] private Image contactIconVideoCall;
    [SerializeField] private TextMeshProUGUI contactVideoCallNameText;
    [SerializeField] private TextMeshProUGUI contactVideoCallNumberText;
    [SerializeField] public VideoClip contactVideoCallClip;

    public Contact currentContact { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        for(int i = 0; i < _contacts.Length; i++)
        {
            _contacts[i].Init();
            _contacts[i].onClick += OnClick;
        }

        int enableCount = 0;
        for (int i = 0; i < _contacts.Length; i++)
        {
            _contacts[i].UpdateContact();

            if (_contacts[i].IsEnable)
            {
                enableCount++;
            }
        }

        if (enableCount == 0)
        {
            _contacts[0].SetActive(true);
        }
    }
    private void OnClick(Contact contact)
    {
        DisableAll();
        currentContact = contact;


        // Menu
        contactIconMenuPanel.sprite = contact.Icon;
        contactMenuNameText.text = contact.Name;

        // Chat
        contactIconChat.sprite = contact.Icon;
        contactChatNameTextChat.text = contact.Name;

        // Call
        contactIconCall.sprite = contact.Icon;
        contactCallNameText.text = contact.Name;
        contactCallNumberText.text = contact.TextNumber;
        contactCallAudioClip = contact.AudioClip;


        // PickUpCall
        contactIconPickUpCall.sprite = contact.Icon;
        contactPickUpCallNameText.text = contact.Name;
        contactPickUpCallNumberText.text = contact.TextNumber;

        // VideoCall
        contactIconVideoCall.sprite = contact.Icon;
        contactVideoCallNameText.text = contact.Name;
        contactVideoCallNumberText.text = contact.TextNumber;

        // PickUp VideoCall
        contactVideoCallClip = contact.VideoClip;
    }

    private void DisableAll()
    {
        for (int i = 0; i < _contacts.Length; i++)
        {
            _contacts[i].Hide();
        }
    }
}

public class Contact
{
    public string Name { get; private set; } 
    public Sprite Icon { get; private set; }
    public string TextNumber { get; private set; }
    public AudioClip AudioClip { get; private set; }
    public VideoClip VideoClip { get; private set; }
    public Contact(string name, Sprite icon, string textNumber, AudioClip audioClip, VideoClip videoClip)
    {
        Name = name;
        Icon = icon;
        TextNumber = textNumber;
        AudioClip = audioClip;
        VideoClip = videoClip;
    }
}
