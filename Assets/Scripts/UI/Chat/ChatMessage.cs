using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] private Image _imageComponent;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    [SerializeField] private Sprite _smallChatBackground;
    [SerializeField] private Sprite _bigChatBackground;

    public readonly float MaxWidthSize = 900;
    public readonly float DefaultHeightSize = 200;

    [HideInInspector] public UnityEvent<float> onHeightChange;

    public void SetMessage(string data)
    {
        SetMessageSize(data);
        _descriptionText.text = data;
    }

    private void SetMessageSize(string data)
    {
        float width = GetMessageSize(data);
        float offset = 0;

        if (width > MaxWidthSize)
        {
            offset = width - (MaxWidthSize + DefaultHeightSize);
            width = MaxWidthSize;
        }

        float x = width;
        float y = DefaultHeightSize + offset;

        y = Mathf.Max(y, DefaultHeightSize);

        onHeightChange?.Invoke(y);

        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, y);
        _imageComponent.rectTransform.sizeDelta = new Vector2(x, y);

        if(x > 400)
        {
            _imageComponent.sprite = _bigChatBackground;
        }
        else
        {
            _imageComponent.sprite = _smallChatBackground;
        }
    }

    private float GetMessageSize(string data)
    {
        float value = data.Length * 40; // 30px per char
        return value < 250 ? 250 : value;
    }
}
