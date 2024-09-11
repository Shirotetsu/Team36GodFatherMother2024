using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseManager : MonoBehaviour
{
    [Serializable]
    public class Disease
    {
        public string name;
        public DiseaseType diseaseType;
        public bool allowToPass;
        public int serialNumber;
    }

    public enum DiseaseType
    {
        Sida,
        Rhume,
        Colera
    }

    public List<Disease> diseases = new List<Disease>();

    public void Start()
    {
        foreach (Disease disease in diseases)
        {
            int random = UnityEngine.Random.Range(0, 2);
            disease.allowToPass = random > 0 ? true : false;

            Debug.Log($"{disease.name} + { random } {disease.allowToPass}");
        }
    }
}
