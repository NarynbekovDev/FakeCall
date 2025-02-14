using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSound : MonoBehaviour
{
    public static CallSound Instance { get; private set; }

    [SerializeField] private AudioClip sounds;
    [SerializeField] private AudioSource audioSourse;
    [SerializeField] private GameObject audioPanel;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSourse.clip = sounds;
        audioSourse.Play();
        if (audioPanel.activeInHierarchy == false)
        {
            audioSourse.Stop();
        }
    }

    public void AudioStop()
    {
        audioSourse.Stop();
    }
}
