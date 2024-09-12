using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : MonoBehaviour
{
    private bool _isEnable;
    private int _nbSymptomsFound = 0;
    [SerializeField] List<Symptoms> _symptoms;
    public bool SearchIfContains(Symptoms symptoms)
    {
        foreach (var symptom in _symptoms)
        {
            if (symptoms.name == symptom.name)
            {
                _nbSymptomsFound++;
                _isEnable = true;
                return true;
            }


        }
        return false;
    }
}
