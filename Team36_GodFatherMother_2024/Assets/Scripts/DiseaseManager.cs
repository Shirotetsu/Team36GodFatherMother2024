using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiseaseManager : MonoBehaviour
{
    public enum DiseaseType
    {
        Luminouillade,
        VortexusDoodle,
        TemporaeWhoopsie,
        SylvarisMiaulement,
        ArcanumTricky,
        TemporaeChabada,
        FlammePopSizzle,
        Lumipopcornus,
        NexumBouchon,
        OblivionisOups,
        AetherisChapeau,
        VeridionZouzou,
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

    public int currentSerialNumber = 0;

    public void Start()
    {
        foreach (DiseaseSO disease in diseases)
        {
            int random = UnityEngine.Random.Range(0, 2);
            disease.allowToPass = random > 0 ? true : false;

            //Debug.Log($"{disease.name} + { random } {disease.allowToPass}");
        }
    }

    public bool VerifySerialNumber(PotionType potionType)
    {
        DiseaseSO diseaseLinkToThisSN = diseases.Where(x => x.serialNumber == currentSerialNumber).FirstOrDefault();

        if (diseaseLinkToThisSN.potionType == potionType)
        {
            return true;
        }
        else
        {
            return false;
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
                //m_currentDiseaseType = disease.diseaseType;
            }
        }

        return foundSerialNumber;
    }
}
