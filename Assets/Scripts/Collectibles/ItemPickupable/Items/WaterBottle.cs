using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaterBottle : MonoBehaviour, ICollectible
{

    public static event HandleWaterCollected OnWaterCollected;
    public delegate void HandleWaterCollected(ItemData itemData);
    public ItemData waterData;

    public void Collect()
    {
        Destroy(gameObject);
        OnWaterCollected?.Invoke(waterData);
    }
}
