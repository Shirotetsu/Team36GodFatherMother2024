using DG.Tweening;
using TMPro;
using UnityEngine;

public class SerialNumber : MonoBehaviour
{
    public int currentSerialNumber;

    [SerializeField]
    private TMP_InputField m_inputField;

    [SerializeField]
    private GameObject m_windowToClose;

    [SerializeField]
    private DiseaseManager diseaseManager;

    private Vector3 basePos;

    public void Start()
    {
        basePos = m_windowToClose.transform.position;

        OpenWindow();
    }

    // Call by the On End Edit Event
    public void SetCurrentSerialNumber()
    {
        currentSerialNumber = int.Parse(m_inputField.text);

        if (!diseaseManager.CheckSerialNumber(currentSerialNumber))
        {
            // Display Error Message
            m_inputField.image.DOColor(Color.red, 0.1f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
            m_windowToClose.transform.DOShakeRotation(0.1f, 5);
        }
        else
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(m_inputField.image.DOColor(Color.green, 0.5f).SetEase(Ease.Linear));

            sequence.Append(m_windowToClose.transform.DOMove(Vector3.zero, 0.5f));
            sequence.Join(m_windowToClose.transform.DOScale(0, 0.5f));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OpenWindow();
    }

    public void OpenWindow()
    {
        m_windowToClose.transform.DOMove(basePos, 0.5f).From(0);
        m_windowToClose.transform.DOScale(1, 0.5f).From(0);
        m_inputField.image.color = Color.white;
        m_inputField.text = "";
    }

    private void OnDestroy()
    {
        // Kill ?
    }
}
