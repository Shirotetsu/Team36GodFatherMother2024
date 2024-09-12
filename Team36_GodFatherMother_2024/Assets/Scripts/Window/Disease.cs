using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static DiseaseManager;

public class Disease : MonoBehaviour
{
    private bool _isEnable;
    private int _nbSymptomsFound = 0;
    [SerializeField] public List<Symptoms> _symptoms;
    public TMP_Text _text;
    private void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }


}
