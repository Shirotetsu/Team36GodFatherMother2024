using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VitrailXP : MonoBehaviour
{
    [SerializeField] private List<Window> _windows;
    public void OpenTroubadourButton()
    {
        Debug.Log("I open toubadour");
        _windows[0]?.ShowWindow();
    }

    public void OpenWikiButton()
    {
        Debug.Log("I open Wiki");
        _windows[1]?.ShowWindow();
    }

    /*public void OpenMatriculeButton()
    {
        Debug.Log("I open Matricule");
        _windows[2]?.ShowWindow();
    }*/

    public void OpenVerdictButton()
    {
        Debug.Log("I open Verdict");
        _windows[2]?.ShowWindow();
    }

    public void CloseAllWindowsButton()
    {
        foreach (var item in _windows)
        {
            item.gameObject.SetActive(false);
        }
    }
}
