using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Verdict : Window
{
    [SerializeField]
    private DiseaseManager diseaseManager;

    [SerializeField]
    private GameObject categoryHolder;

    [SerializeField]
    private GameObject recipeHolder;

    // 

    private CategoryType categorySelected;

    [SerializeField]
    private float m_delayBeforeReOpening = 0.5f;

    private bool categoryOpen;

    void Start()
    {
        this.gameObject.SetActive(false);

        categoryOpen = true;
    }

    public void Test(CategoryType categoryType)
    {
        if (categorySelected != null)
        {
            categorySelected.ChangeColorToUnSelected();
        }

        categorySelected = categoryType;

        categoryType.ChangeColorToSelected();
    }
    public void ValidationButton(Image borderColor)
    {
        if (categorySelected == null)
            return;

        borderColor.color = Color.green;

        categoryOpen = false;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(this.gameObject.transform.DOScaleX(0, 0.5f).From(1).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                UpdateHolders();
            }));

        sequence.AppendInterval(m_delayBeforeReOpening);
        sequence.Append(gameObject.transform.DOScaleX(1, 0.5f).From(0).SetEase(Ease.OutBack));
    }

    public void SeRetracter()
    {
        categoryOpen = true;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(this.gameObject.transform.DOScaleX(0, 0.5f).From(1).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                UpdateHolders();
            }));

        sequence.AppendInterval(m_delayBeforeReOpening);
        sequence.Append(gameObject.transform.DOScaleX(1, 0.5f).From(0).SetEase(Ease.OutBack));
    }

    public override void ShowWindow()
    {
        if (diseaseManager.currentSerialNumber <= 10)
        {
            return;
        }

        base.ShowWindow();
        gameObject.transform.DOScaleX(1, 0.5f).From(0).SetEase(Ease.OutBack);

        categoryOpen = true;
        UpdateHolders();
    }

    public override void HideWindow(Window window)
    {
        window.gameObject.transform.DOScaleX(0, 0.5f).From(1).SetEase(Ease.InBack).OnComplete(() =>

        {
            base.HideWindow(window);

            UpdateHolders();
        });

        categoryOpen = true;
    }

    public void Administer()
    {
        diseaseManager.VerifySerialNumber(categorySelected.PotionType);
    }

    private void UpdateHolders()
    {
        if (categoryOpen)
        {
            categoryHolder.SetActive(true);
            recipeHolder.SetActive(false);
        }
        else
        {
            categoryHolder.SetActive(false);
            recipeHolder.SetActive(true);
        }
    }
}
