using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClip audioPiclUpCall;
    [SerializeField] private AudioSource audioSourse;
    [SerializeField] private float timer;
    [SerializeField] private bool stopTimer = false;
    [SerializeField] private Slider sliderAudio;
    [SerializeField] private Image audioImage;
    [SerializeField] private Sprite[] audioSprite;


    private ContactsAssistant _contactsAssistant;
    private void Awake()
    {
        Instance = this;

        _contactsAssistant = FindObjectOfType<ContactsAssistant>().GetComponent<ContactsAssistant>();
    }

    private void Start()
    {
        audioSourse.volume = 1f;
        sliderAudio.value = 1f;
    }


    public void FirstdSound()
    {
        audioSourse.clip = audioPiclUpCall;
        audioSourse.clip = _contactsAssistant.contactCallAudioClip;
        audioSourse.Play();
    }

    public void VolumAudio()
    {
        if (audioSourse.volume <= .75f)
        {
            audioSourse.volume += .33f;
            sliderAudio.value += .33f;
        }
        else if (audioSourse.volume == .75f)
        {
            audioSourse.volume += .34f;
            sliderAudio.value += .34f;
        }
        else if (audioSourse.volume >= .99f) 
        {
            audioSourse.volume = 0f;
            sliderAudio.value = 0f;
        }

        if (audioSourse.volume == 0f)
        {
            audioImage.sprite = audioSprite[0];
        }
        else if (audioSourse.volume == .33f)
        {
            audioImage.sprite = audioSprite[1];
        }
        else if (audioSourse.volume == .66f)
        {
            audioImage.sprite = audioSprite[2];
        }
        else if (audioSourse.volume == .99f)
        {
            audioImage.sprite = audioSprite[3];
        }
    }

    public  void StopCall()
    {
        audioSourse.Stop();
    }

    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.0001f);

            float timeMaxCall = timer;
        }
    }
}
