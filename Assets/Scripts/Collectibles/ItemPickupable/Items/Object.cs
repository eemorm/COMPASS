using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Object : MonoBehaviour, ICollectible, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public static event HandleObjectCollected OnObjectCollected;
    public delegate void HandleObjectCollected(ItemData itemData);
    public ItemData objectData;
    private bool collected = false;

    public void Collect()
    {
        collected = true;
        Destroy(gameObject);
        OnObjectCollected?.Invoke(objectData);
    }

    public void LoadData(GameData data)
    {
        data.itemsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected.Remove(id);
        }
        data.itemsCollected.Add(id, collected);
    }
}