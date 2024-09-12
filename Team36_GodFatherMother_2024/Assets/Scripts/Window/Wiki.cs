using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Wiki : Window
{
    [SerializeField] List<Toggle> _toggles;
    [SerializeField] List<Symptoms> _symptoms;
    [SerializeField] List<Disease> _diseases;
    private Dictionary<Toggle, Symptoms> _symptomsDict;


    private void Start()
    {
        var i = 0;
        foreach (var tog in _toggles)
        {
            _symptomsDict[tog] = _symptoms[i];
            i++;
        }

        foreach (var symptom in _symptomsDict)
        {
            if (symptom.Key.isOn)
            {
                _diseases.ForEach(disease => { var IsContain = disease.SearchIfContains(symptom.Value); });
               
            }
        }
    }

   
}
