using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    //[SerializeField] private VideoClip videoPiclUpCall;
    [SerializeField] private VideoPlayer videoSourse;

    private ContactsAssistant _contactsAssistant;

    private void Awake()
    {
        _contactsAssistant = FindObjectOfType<ContactsAssistant>().GetComponent<ContactsAssistant>();
    }

    public void VideoPlay()
    {
        //videoSourse.clip = videoPiclUpCall;
        videoSourse.clip = _contactsAssistant.contactVideoCallClip;
        //videoSourse.Play();
    }
}
