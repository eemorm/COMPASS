using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bandage : MonoBehaviour, ICollectible
{

    public static event HandleBandageCollected OnBandageCollected;
    public delegate void HandleBandageCollected(ItemData itemData);
    public ItemData bandageData;

    public void Collect()
    {
        Destroy(gameObject);
        OnBandageCollected?.Invoke(bandageData);
    }
}
