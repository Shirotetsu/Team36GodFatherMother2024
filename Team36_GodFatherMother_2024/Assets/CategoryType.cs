using UnityEngine;
using UnityEngine.UI;

public class CategoryType : MonoBehaviour
{
    [SerializeField]
    private Image backgroundBorderColor;

    [SerializeField]
    private PotionType potionType;
    public PotionType PotionType => potionType;

    public void ChangeColorToSelected()
    {
        backgroundBorderColor.color = Color.green;
    }

    public void ChangeColorToUnSelected()
    {
        backgroundBorderColor.color = Color.black;
    }
}
