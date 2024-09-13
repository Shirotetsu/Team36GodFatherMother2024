using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Troubabook : Window
{
    enum Personnage
    {
        HostingPage,
        Yvain,
        Gauvain,
        Mainard,
    }
    private TMP_Dropdown _dropdown;
    [SerializeField] private Personnage _personnage;
    private Image _image;
    [SerializeField] private List<Sprite> _sprites;

    private void Start()
    {
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
        _image = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        _personnage = (Personnage)_dropdown?.value;
        _image.sprite = Search();

    }
    public Sprite Search() //Search and print the Personnage page
    {
        Sprite sprite;
        switch (_personnage)
        {
            case Personnage.Gauvain:
                sprite = _sprites[0];
                break;
            case Personnage.Yvain:
                sprite = _sprites[1];
                break;
            case Personnage.Mainard:
                sprite = _sprites[2];
                break;
            case Personnage.HostingPage:
                sprite = _sprites[3];
                break;
            default:
                Debug.Log("test");
                sprite = null;
                break;
        }
        return sprite;
    }
}
