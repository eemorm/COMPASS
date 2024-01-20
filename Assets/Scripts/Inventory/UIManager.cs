using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    // Reference to your UI elements outside the prefab
    public Image stars;
    public TextMeshProUGUI description;
    public TextMeshProUGUI modifiers;
    public Image bigicon;
    public TextMeshProUGUI labelText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateDetailedInfo(ItemData itemData)
    {
        // Modify UI elements outside the prefab based on itemData
        if (description != null)
        {
            description.text = itemData.description;
        }

        // You can similarly update other UI elements based on itemData
        if (modifiers != null)
        {
            modifiers.text = itemData.modifiers;
        }

        if (stars != null)
        {
            stars.sprite = itemData.stars;
            stars.color = new Color(1f, 1f, 1f, 1f);
        }

        if (bigicon != null)
        {
            bigicon.sprite = itemData.icon;
            bigicon.color = new Color(1f, 1f, 1f, 1f);
        }

        if (labelText != null)
        {
            labelText.text = itemData.name;
        }
    }

    public void ClearDetailedInfo()
    {
        // Clear or reset UI elements outside the prefab
        if (description != null)
        {
            description.text = "";
        }

        // Similarly, clear or reset other UI elements
        if (modifiers != null)
        {
            modifiers.text = "";
        }

        if (stars != null)
        {
            stars.sprite = null;
            stars.color = new Color(1f, 1f, 1f, 0f);
        }

        if (bigicon != null)
        {
            bigicon.sprite = null;
            bigicon.color = new Color(1f, 1f, 1f, 0f);
        }

        if (labelText != null)
        {
            labelText.text = ""; // Clear or reset your custom text
        }
    }
}