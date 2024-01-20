using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CandyBar : MonoBehaviour, ICollectible
{

    public static event HandleCandyCollected OnCandyCollected;
    public delegate void HandleCandyCollected(ItemData itemData);
    public ItemData candyData;

    public void Collect()
    {
        Destroy(gameObject);
        OnCandyCollected?.Invoke(candyData);
    }
}
