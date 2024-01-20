using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{

    public float SceneNumber;
    public void MoveToSetScene()
    {
        SceneManager.LoadScene((int)SceneNumber);
    }
}
