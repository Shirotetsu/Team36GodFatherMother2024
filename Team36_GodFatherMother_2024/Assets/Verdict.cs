using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject m_textGreen;
    [SerializeField]
    private GameObject m_textRed;
    [SerializeField]
    private GameObject m_textBlue;

    [SerializeField]
    private GameObject m_Win;
    [SerializeField]
    private GameObject m_Lose;

    [SerializeField]
    private GameObject m_loading;

    void Start()
    {
        if(!gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }

        categoryOpen = true;

        m_Win.SetActive(false);
        m_Lose.SetActive(false);
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

                if (categorySelected.PotionType == PotionType.Green)
                {
                    m_textGreen.SetActive(true);
                    m_textRed.SetActive(false);
                    m_textBlue.SetActive(false);
                }
                if (categorySelected.PotionType == PotionType.Red)
                {
                    m_textGreen.SetActive(false);
                    m_textRed.SetActive(true);
                    m_textBlue.SetActive(false);
                }
                if (categorySelected.PotionType == PotionType.Blue)
                {
                    m_textGreen.SetActive(false);
                    m_textRed.SetActive(false);
                    m_textBlue.SetActive(true);
                }
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
        m_Win.SetActive(false);
        m_Lose.SetActive(false);

        if (diseaseManager.VerifySerialNumber(categorySelected.PotionType))
        {
            // Win
            //m_Win.SetActive(true);
            PlayLoadingAnimation(true);
        }
        else
        {
            // Lose
            PlayLoadingAnimation(false);
        }
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

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLoadingAnimation(bool _win)
    {
        m_loading.SetActive(true);
        m_loading.transform.DOLocalRotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
                .SetRelative(true).SetLoops(5).SetEase(Ease.Linear).OnComplete(() =>
                {
                    m_Win.SetActive(_win);
                    m_Lose.SetActive(!_win);
                    m_loading.SetActive(false);
                });
    }
}
