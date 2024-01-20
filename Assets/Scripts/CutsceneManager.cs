using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector startCutscene;
    public GameObject startCutsceneCanvas;
    public SceneFlags sceneFlags;
    public GameObject player;
    
    void Update()
    {
        if (sceneFlags.startCutscene == true)
        {
            player.SetActive(false);
            startCutsceneCanvas.SetActive(true);
            startCutscene.Play();
            if (startCutscene.time >= startCutscene.duration)
            {
                // Cutscene is done, perform any actions you need
                sceneFlags.startCutscene = false; // Set to false to avoid replaying the cutscene
                player.SetActive(true);
            }

        }
        else
        {
            startCutsceneCanvas.SetActive(false);
        }
    }
}
