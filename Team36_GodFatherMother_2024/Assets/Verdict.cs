using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Verdict : Window
{
    private CategoryType categorySelected;

    [SerializeField]
    private GameObject categoryHolder;

    [SerializeField]
    private GameObject recipeHolder;

    [SerializeField]
    private float m_delayBeforeReOpening = 0.5f;

    void Start()
    {
        this.gameObject.SetActive(false);
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

        Debug.Log("Validation");

        Sequence sequence = DOTween.Sequence();
        sequence.Append(this.gameObject.transform.DOScaleX(0, 0.5f).From(1).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                categoryHolder.SetActive(false);
                recipeHolder.SetActive(true);
            }));

        sequence.AppendInterval(m_delayBeforeReOpening);
        sequence.Append(gameObject.transform.DOScaleX(1, 0.5f).From(0).SetEase(Ease.OutBack));
    }

    public override void ShowWindow()
    {
        base.ShowWindow();
        gameObject.transform.DOScaleX(1, 0.5f).From(0).SetEase(Ease.OutBack);
    }

    public override void HideWindow(Window window)
    {
        window.gameObject.transform.DOScaleX(0, 0.5f).From(1).SetEase(Ease.InBack).OnComplete(() => base.HideWindow(window));
    }
}
