using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SerialNumber : MonoBehaviour
{
    public int currentSerialNumber;

    [SerializeField]
    private TMP_InputField m_textMeshProUGUI;

    [SerializeField]
    private DiseaseManager diseaseManager;

    public void SetCurrentSerialNumber()
    {
        currentSerialNumber = int.Parse(m_textMeshProUGUI.text);

        if (!diseaseManager.CheckSerialNumber(currentSerialNumber))
        {
            // Display Error Message
            m_textMeshProUGUI.image.color = Color.red;
            Debug.Log("Hello");
        }
    }
}
