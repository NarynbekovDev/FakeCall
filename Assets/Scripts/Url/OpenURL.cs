using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenWebSite(string url = "http://unity3d.com")
    {
        Application.OpenURL(url);
    }
}
