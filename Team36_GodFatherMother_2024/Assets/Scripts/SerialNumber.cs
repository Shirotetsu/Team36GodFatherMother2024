using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SerialNumber : MonoBehaviour
{
    public int currentSerialNumber;

    [SerializeField]
    private TMP_InputField m_textMeshProUGUI;

    [SerializeField]
    private GameObject m_windowToClose;

    [SerializeField]
    private DiseaseManager diseaseManager;

    public void SetCurrentSerialNumber()
    {
        currentSerialNumber = int.Parse(m_textMeshProUGUI.text);

        if (!diseaseManager.CheckSerialNumber(currentSerialNumber))
        {
            // Display Error Message
            m_textMeshProUGUI.image.DOColor(Color.red, 0.1f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
        }
        else
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(m_textMeshProUGUI.image.DOColor(Color.green, 0.5f).SetEase(Ease.Linear));
            sequence.Append(m_windowToClose.transform.DOScale(0, 0.5f));
        }
    }
}
