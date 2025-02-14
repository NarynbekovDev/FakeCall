using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneButton : MonoBehaviour
{
    [SerializeField] private Image microphoneImage;
    [SerializeField] private Sprite onMicrophone;
    [SerializeField] private Sprite offMicrophone;


    public void OnMicrophone()
    {
        if (microphoneImage.sprite == offMicrophone)
        {
            microphoneImage.sprite = onMicrophone;
        }
        else if (microphoneImage.sprite == onMicrophone)
        {
            microphoneImage.sprite = offMicrophone;
        }
    }
}
