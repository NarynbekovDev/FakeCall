using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoCallSound : MonoBehaviour
{
    [SerializeField] private AudioClip sounds;
    [SerializeField] private AudioSource audioSourse;
    [SerializeField] private GameObject videoCallPanel;

    private void Start()
    {
        audioSourse.clip = sounds;
        audioSourse.Play();
        if (videoCallPanel.activeInHierarchy == false)
        {
            audioSourse.Stop();
        }
    }
}
