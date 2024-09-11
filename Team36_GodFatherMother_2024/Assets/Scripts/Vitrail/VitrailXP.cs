using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VitrailXP : MonoBehaviour
{
    private Window _window;
    public void OpenTroubadour()
    {
        _window.Windows[0].ShowWindow(_window.Windows[0]);
    }

    public void OpenWiki()
    {
        _window.Windows[1].ShowWindow(_window.Windows[1]);
    }
}
