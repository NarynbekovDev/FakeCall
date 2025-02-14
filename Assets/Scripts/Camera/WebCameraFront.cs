using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WebCameraFront : MonoBehaviour
{
    [SerializeField] public RawImage display;

    private int _currentCamIndex = 1;
    private WebCamTexture _tex;


    private void Start()
    {
        StartCam();
    }

    public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            _currentCamIndex += 0;
            _currentCamIndex %= WebCamTexture.devices.Length;
        }

        _currentCamIndex = 1;
    }

    public void StartCam()
    {
        if (_tex == null)
        {
            WebCamDevice devise = WebCamTexture.devices[_currentCamIndex];
            _tex = new WebCamTexture(devise.name);
            display.texture = _tex;

            float antiRotate = -(360 - _tex.videoRotationAngle);
            Quaternion quatRot = new Quaternion();
            quatRot.eulerAngles = new Vector3(0, 0, antiRotate);

            _tex.Play();

            //float ratio = (float)_tex.width / (float)_tex.height;
            //fit.aspectRatio = ratio;

            //float scaleY = _tex.videoVerticallyMirrored ? 1f : 1f;
            //display.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            //int orient = -_tex.videoRotationAngle;
            //display.rectTransform.localEulerAngles = new Vector3(0, -180, orient);
            //_tex.Play();
        }
    }

    public void StopCam()
    {
        if (_tex != null)
        {
            display.texture = null;
            _tex.Stop();
            _tex = null;
        }
    }

}
