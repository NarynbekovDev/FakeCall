using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] private Slider timerSlider;
    [SerializeField] private float timer;
    [SerializeField] private float maxValue;
    [SerializeField] private bool stopTimer = false;
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private GameObject PrivacyPanel;
    [SerializeField] private TextMeshProUGUI textSlider;

    private float _onePercent;


    //private void Start()
    //{
    //    loadingPanel.SetActive(true);
    //    PrivacyPanel.SetActive(false);

    //    timerSlider.maxValue = maxValue;
    //    timerSlider.value = timer;

    //    //if (loadingPanel.activeInHierarchy == true)
    //    //{
    //    //    StartTimer();
    //    //}

    //    _onePercent = maxValue / 100;
    //}

    public void StartTimer()
    {
        timer = 0;
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        timerSlider.maxValue = maxValue;
        timerSlider.value = timer;

        _onePercent = maxValue / 100;

        while (stopTimer == false)
        {
            timer += Time.deltaTime;
            float percent = timer / _onePercent;
            int result = (int)percent;
            textSlider.text = result + "%";

            if (timer >= maxValue)
            {
                //stopTimer = true;
                loadingPanel.SetActive(false);
                PrivacyPanel.SetActive(true);
            }

            if (stopTimer == false)
            {
                timerSlider.value = timer;
            }

            yield return null;
        }
    }

    public void StopTimer()
    {
        stopTimer = false;
    }
}
