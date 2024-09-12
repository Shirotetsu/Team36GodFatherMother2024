using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Window : MonoBehaviour
{
    public virtual void ShowWindow() //print window
    {
        transform.SetAsLastSibling(); //change the order of hierarchy
        gameObject.SetActive(true);
    }

    public virtual void HideWindow(Window window) //hide window
    {
        window.gameObject.SetActive(false);
        Debug.Log("dqdq");
    }
}
