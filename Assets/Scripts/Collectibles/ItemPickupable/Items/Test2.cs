using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test2 : MonoBehaviour, ICollectible
{

    public static event HandleHeheCollected OnHeheCollected;
    public delegate void HandleHeheCollected(ItemData itemData);
    public ItemData heheData;

    public void Collect()
    {
        Destroy(gameObject);
        OnHeheCollected?.Invoke(heheData);
    }
}
