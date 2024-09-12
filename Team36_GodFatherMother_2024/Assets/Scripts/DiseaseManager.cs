using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseManager : MonoBehaviour
{
    public enum DiseaseType
    {
        Sida,
        Rhume,
        Colera
    }

    public enum Symptoms
    {
        Parano,
        Liar,
        Scared
    }

    [SerializeField]
    private List<DiseaseSO> diseases = new List<DiseaseSO>();

    private DiseaseType m_currentDiseaseType;


    public void Start()
    {
        foreach (DiseaseSO disease in diseases)
        {
            int random = UnityEngine.Random.Range(0, 2);
            disease.allowToPass = random > 0 ? true : false;

            //Debug.Log($"{disease.name} + { random } {disease.allowToPass}");
        }
    }

    public bool CheckSerialNumber(int _serialNumber)
    {
        bool foundSerialNumber = false;

        foreach (DiseaseSO disease in diseases)
        {
            if (_serialNumber == disease.serialNumber)
            {
                foundSerialNumber = true;
                m_currentDiseaseType = disease.diseaseType;
            }
        }

        return foundSerialNumber;
    }
}
