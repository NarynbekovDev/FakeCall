using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChatVariant : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Button _btnVariant;
    [SerializeField] private TextMeshProUGUI _txtTitle;
    [SerializeField] private RectTransform _rectTransform;

    private string _textKey;
    private string _answerKey;

    public void InitVariant(UnityAction<string, string> onClick, string textKey, string answerKey)
    {
        _textKey = textKey;
        _answerKey = answerKey;
        _btnVariant.onClick.AddListener(() => {
            onClick?.Invoke(_textKey, answerKey);
        });
        _txtTitle.text = LocalizerAssistant.GetText(textKey);

        SetButtonSize(_txtTitle.text);
    }

    private void SetButtonSize(string data)
    {
        float value = 0;
        if (data.Length <= 1) value = 150;
        else if (data.Length <= 8) value = 200;
        else if (data.Length <= 15) value = 250;
        else value = 400;

        _rectTransform.sizeDelta = new Vector2(value, _rectTransform.sizeDelta.y);
    }
}
