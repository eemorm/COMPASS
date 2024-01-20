using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public float[] position;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public SerializableDictionary<string, bool> itemsCollected;
    public bool startCutscene;

    public GameData()
    {
        this.position = new float[2];
        position[0] = 0;
        position[1] = 0;

        inventory = new List<InventoryItem>(0);
        itemsCollected = new SerializableDictionary<string, bool>();

        startCutscene = true;
    }
}
