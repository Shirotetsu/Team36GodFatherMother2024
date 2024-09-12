using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static DiseaseManager;

public class Wiki : Window
{
    [SerializeField] List<Toggle> _toggles;
    [SerializeField] List<Symptoms> _symptoms;
    [SerializeField] List<Disease> _diseases;
    private List<Symptoms> _CheckingList = new List<Symptoms>();
    private int _nbTogglePressed;
    [SerializeField] private TMP_Text _textMeshPro;
    private Symptoms symptomforList;

    private void Start()
    {



    }

    public void GetSymptom(Symptoms symptoms)
    {
        symptomforList = symptoms;
    }
    public void OnTogglePressed(Toggle toggle)
    {
        var symptom = symptomforList;
        if (toggle.isOn)
        {
            AddToList(symptom);
            CompareList();
        }
        else
        {
            RemoveFromList(symptom);
            CheckListForErase();
        }
        foreach (var item in _CheckingList)
        {
            Debug.Log(item.name);
        }
    }
    public void AddToList(Symptoms symptoms)
    {
        _CheckingList?.Add(symptoms);
    }

    public void RemoveFromList(Symptoms symptoms)
    {
        _CheckingList?.Remove(symptoms);
    }


    public int CompareList()
    {
        switch (_CheckingList.Count)
        {
            case 0:
                break;
            case 1:
                CheckList();
                break;
            case 2:
                CheckList();
                break;
            case 3:
                CheckList();
                break;
            default:
                break;
        }
        return 0;
    }

    public void CheckList()
    {
        foreach (var disease in _diseases)
        {
            foreach (var symp in _CheckingList)
            {
                if (disease._symptoms.Contains(symp))
                {
                    disease._text.gameObject.SetActive(true);
                }
                else
                {
                    disease._text.gameObject.SetActive(false);
                }
            }
        }
    }

    public void CheckListForErase()
    {
        foreach (var disease in _diseases)
        {
            foreach (var symp in _CheckingList)
            {
                if (!disease._symptoms.Contains(symp))
                {
                    disease._text.gameObject.SetActive(false);
                }

            }
        }
    }
    public void CheckListof3()
    {
        foreach (var disease in _diseases)
        {
            if (_CheckingList == disease._symptoms)
            {
                disease._text.gameObject.SetActive(true);
            }
        }
    }

}
