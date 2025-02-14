using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewerCount : MonoBehaviour
{
    [SerializeField] private int countViewers = 0;
    [SerializeField] private int randomViewers;
    [SerializeField] private int maxViewers;
    [SerializeField] private TextMeshProUGUI viewerText;


    private void Update()
    {
        if (maxViewers <= 10000)
        {
            randomViewers = Random.Range(1, 5);
            countViewers = (int)Time.deltaTime + randomViewers;
            maxViewers += countViewers;

            viewerText.text = maxViewers.ToString();
        }
    }
}
