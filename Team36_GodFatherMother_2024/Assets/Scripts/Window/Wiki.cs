using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wiki : Window
{
    [SerializeField] List<Toggle> _toggles;
    [SerializeField] List<Symptoms> _symptoms;
    [SerializeField] List<Disease> _diseases;
    private List<Disease> _possibleDiseases;
    private List<Symptoms> _CheckingList = new List<Symptoms>();
    [SerializeField] private TMP_Text _textMeshPro;

    private void Start()
    {
        DisplayPossibleDiseases();
        _possibleDiseases = new List<Disease>(_diseases);
        LinkTogglesWithSymptoms(); 
    }

    
    private void LinkTogglesWithSymptoms()
    {
        for (int i = 0; i < _toggles.Count; i++)
        {
            int index = i; 
            _toggles[i].onValueChanged.AddListener(delegate { OnTogglePressed(_toggles[index], _symptoms[index]); });
        }
    }


    public void OnTogglePressed(Toggle toggle, Symptoms symptom)
    {
        if (toggle.isOn)
        {
            AddToList(symptom);
        }
        else
        {
            RemoveFromList(symptom);
        }

        DisplayPossibleDiseases(); 
    }

  
    public void AddToList(Symptoms symptom)
    {
        if (!_CheckingList.Contains(symptom))
        {
            _CheckingList.Add(symptom);
            DiseaseFilter(); // Filtrer après ajout
        }
    }

   
    public void RemoveFromList(Symptoms symptom)
    {
        if (_CheckingList.Contains(symptom))
        {
            _CheckingList.Remove(symptom);
            DiseaseFilter(); 
        }
    }


    public void DiseaseFilter()
    {
        _possibleDiseases = new List<Disease>(_diseases);

        
        foreach (var disease in _diseases)
        {
            if (!DiseaseContainsSymptoms(disease))
            {
                _possibleDiseases.Remove(disease);
            }
        }
    }

  
    public bool DiseaseContainsSymptoms(Disease disease)
    {
        foreach (var symptom in _CheckingList)
        {
            if (!disease._symptoms.Contains(symptom))
            {
                return false; 
            }
        }
        return true; 
    }

    
    private void DisplayPossibleDiseases()
    {
        _textMeshPro.text = "Possible Diseases:\n";
        foreach (var disease in _possibleDiseases)
        {
            _textMeshPro.text += disease.name + "\n";
        }
    }
}
