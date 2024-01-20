// SceneFlags.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFlags : MonoBehaviour, IDataPersistence
{
    public bool startCutscene = true;

    public void LoadData(GameData gameData)
    {
        startCutscene = gameData.startCutscene; // Change to startCutscene
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.startCutscene = startCutscene; // Change to startCutscene
    }
}
