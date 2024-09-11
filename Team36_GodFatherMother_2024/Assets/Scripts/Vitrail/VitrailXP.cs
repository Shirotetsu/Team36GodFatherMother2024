using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class VitrailXP : MonoBehaviour
{
    [SerializeField] private Window _window;
    public void OpenTroubadourButton()
    {
        Debug.Log("I open toubadour");
        _window.Windows[0]?.ShowWindow();
    }

    public void OpenWikiButton()
    {
        Debug.Log("I open Wiki");
        _window.Windows[1]?.ShowWindow();
    }

    public void OpenMatriculeButton()
    {
        Debug.Log("I open Matricule");
        _window.Windows[2]?.ShowWindow();
    }

    public void OpenVerdictButton()
    {
        Debug.Log("I open Verdict");
        _window.Windows[3]?.ShowWindow();
    }

    public void CloseAllWindowsButton()
    {
        foreach (var item in _window.Windows)
        {
            item.gameObject.SetActive(false);
        }
    }
}
