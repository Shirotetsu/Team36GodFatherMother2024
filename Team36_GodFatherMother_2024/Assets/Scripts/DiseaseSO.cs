using System.Collections.Generic;
using UnityEngine;
using static DiseaseManager;

[CreateAssetMenu(fileName = "DiseaseSO", menuName = "ScriptableObjects/DiseaseSO", order = 1)]
public class DiseaseSO : ScriptableObject
{
    public string name;
    //public DiseaseType diseaseType;
    public PotionType potionType;
    public bool allowToPass;
    public int serialNumber;

    public List<Symptoms> symptoms;

    [TextArea]
    public string Description;
}

public enum PotionType
{
    Green, 
    Red, 
    Blue
}