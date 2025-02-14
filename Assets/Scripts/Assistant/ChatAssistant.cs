using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ChatItem
{
    [field: SerializeField]
    public string TextKey { get; private set; }
    [field: SerializeField]
    public string AnswerKey { get; private set; }
}

public class ChatAssistant : MonoBehaviour
{
    [Header("Upper panel")]
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private string _defaultText;
    [SerializeField] private string _onTypingText;

    [Header("Variants Components")]
    [SerializeField] private ChatVariant _variantPrefab;
    [SerializeField] private RectTransform _variantsContainer;

    [Header("Message Components")]
    [SerializeField] private ChatMessage _playerMessagePrefab;
    [SerializeField] private ChatMessage _botMessagePrefab;
    [SerializeField] private RectTransform _messagesContainer;
    [SerializeField] private Button _clearBtn;

    [Header("Variants")]
    [SerializeField] private string _initText;
    [SerializeField] private ChatItem[] _variants;

    private List<ChatVariant> _chats = new List<ChatVariant>();
    private List<ChatMessage> _messages = new List<ChatMessage>();

    private Vector2 _startMessagesContainerSize;

    private void Start()
    {
        InitVariants();
        _clearBtn.onClick.AddListener(ClearMessages);
        var msg = Instantiate(_botMessagePrefab, _messagesContainer);
        msg.SetMessage(LocalizerAssistant.GetText(_initText));

        _startMessagesContainerSize = _messagesContainer.sizeDelta;

        _statusText.text = _defaultText;
    }

    private void InitVariants()
    {
        for (int i = 0; i < _chats.Count; i++)
        {
            Destroy(_chats[i].gameObject);
        }

        _chats.Clear();

        SetContainerSize();

        for(int i = 0; i < _variants.Length; i++)
        {
            var variant = Instantiate(_variantPrefab, _variantsContainer);
            variant.InitVariant(OnClick, _variants[i].TextKey, _variants[i].AnswerKey);
            _chats.Add(variant);
        }
    }
  
    private void OnClick(string textKey, string answerKey)
    {
        string text = LocalizerAssistant.GetText(textKey);
        string answer = LocalizerAssistant.GetText(answerKey);

        StartCoroutine(CreateMessagesRoutine(text, answer));
    }

    private IEnumerator CreateMessagesRoutine(string text, string answer)
    {
        ChatMessage a = GetNewMessageSlot(_playerMessagePrefab);
        a.SetMessage(text);

        _statusText.text = _onTypingText;
        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));
        _statusText.text = _defaultText;

        ChatMessage b = GetNewMessageSlot(_botMessagePrefab);
        b.SetMessage(answer);
    }

    private ChatMessage GetNewMessageSlot(ChatMessage message)
    {
        ChatMessage msg = Instantiate(message, _messagesContainer);
        msg.onHeightChange.AddListener(OnHeightChange);
        _messages.Add(msg);
        return msg; 
    }

    private void OnHeightChange(float height)
    {
        float x = _messagesContainer.sizeDelta.x;
        float y = _messagesContainer.sizeDelta.y;
        _messagesContainer.sizeDelta = new Vector2(x, y + height);
    }
    private void SetContainerSize()
    {
        float value = _variants.Length * 450;

        _variantsContainer.sizeDelta = new Vector2(value, _variantsContainer.sizeDelta.y);
    }

    private void ClearMessages()
    {
        for(int i =0; i < _messages.Count; i++) 
        {
            Destroy(_messages[i].gameObject);
        }
        _messages.Clear();

        _messagesContainer.sizeDelta = _startMessagesContainerSize;
    }
}
