using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Verdict : Window
{
    private CategoryType categorySelected;

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
    }
}
