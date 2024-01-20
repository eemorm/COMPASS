using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject OptionsCanvas;
    public GameObject SaveCanvas;
    public void ToOptions()
    {
        StartCanvas.SetActive(false);
        OptionsCanvas.SetActive(true); 
    }

    public void ToStart()
    {
        OptionsCanvas.SetActive(false);
        SaveCanvas.SetActive(false);
        StartCanvas.SetActive(true);
    }
    public void ToSave()
    {
        StartCanvas.SetActive(false);
        SaveCanvas.SetActive(true);
    }
}
