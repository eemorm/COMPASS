using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soda : MonoBehaviour, ICollectible
{

    public static event HandleSodaCollected OnSodaCollected;
    public delegate void HandleSodaCollected(ItemData itemData);
    public ItemData sodaData;

    public void Collect()
    {
        Destroy(gameObject);
        OnSodaCollected?.Invoke(sodaData);
    }
}
