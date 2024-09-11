using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private List<Window> _windows;
    [SerializeField] private Troubabook _troubabook;
    [SerializeField] private Wiki _wiki;
    public List<Window> Windows { get => _windows; set => _windows = value; }


    private void Start()
    {
        _windows.Add(_troubabook);
        _windows.Add(_wiki);
    }

    public void ShowWindow(Window window)
    {
        window.gameObject.SetActive(true);
    }

    public void HideWindow(Window window)
    {
        window.gameObject.SetActive(false);
    }

}
