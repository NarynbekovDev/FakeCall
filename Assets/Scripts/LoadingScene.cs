using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private int sceneID;

    public void MoveToScene()
    {
        SceneManager.LoadScene(sceneID);
    }
}
