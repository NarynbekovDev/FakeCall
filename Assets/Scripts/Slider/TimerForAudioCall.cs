using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerForAudioCall : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float _elapsedTime;
    private int minute;
    private int second;

    public void StartButton()
    {
        _elapsedTime = 0f;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        minute = Mathf.FloorToInt(_elapsedTime / 60);
        second = Mathf.FloorToInt(_elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
