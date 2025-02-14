using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsPanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject contactsPanel;

    public void BackButton()
    {
        menuPanel.SetActive(true);
        contactsPanel.SetActive(false);
    }
}
