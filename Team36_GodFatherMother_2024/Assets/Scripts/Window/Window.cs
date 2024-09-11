using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private List<Window> _windows;
    public List<Window> Windows { get => _windows; set => _windows = value; }



    public void ShowWindow() //print window
    {
        transform.SetAsLastSibling(); //change the order of hierarchy
        gameObject.SetActive(true);
    }

    public void HideWindow(Window window) //hide window
    {
        window.gameObject.SetActive(false);
    }
}
