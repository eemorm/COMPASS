using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public List<Button> tabButtons = new List<Button>();
    public string selectedTabType;

    public void OnTabButtonClick(string tabType)
    {
        SetButtonSelected(tabType);
        selectedTabType = tabType;
    }

    private void SetButtonSelected(string selectedType)
    {
        foreach (Button button in tabButtons)
        {
            string buttonText = button.GetComponentInChildren<Text>().text;
            bool isSelected = buttonText.Equals(selectedType, StringComparison.OrdinalIgnoreCase);
            ColorBlock colors = button.colors;

            if (isSelected)
            {
                colors.normalColor = button.colors.selectedColor; // Use selectedColor as the normal color for the selected tab
                colors.highlightedColor = button.colors.selectedColor;
                colors.pressedColor = button.colors.selectedColor;
            }
            else
            {
                colors.normalColor = button.colors.normalColor; // Reset to the original normal color
                colors.highlightedColor = button.colors.highlightedColor;
                colors.pressedColor = button.colors.pressedColor;
            }

            button.colors = colors;
        }
    }
}
