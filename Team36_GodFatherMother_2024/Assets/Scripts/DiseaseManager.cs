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

    public void Start()
    {
        foreach (DiseaseSO disease in diseases)
        {
            int random = UnityEngine.Random.Range(0, 2);
            disease.allowToPass = random > 0 ? true : false;

            Debug.Log($"{disease.name} + { random } {disease.allowToPass}");
        }
    }
}
