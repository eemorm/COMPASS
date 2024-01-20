using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class TriggerNPC : MonoBehaviour
{
    public GameObject parent;
    public GameObject dialogueCanvas;
    public PlayerMovement playerMovement;
    public GameObject vc1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("You collided with an NPC");
            parent.GetComponent<Dialogue>().StartDialogue();
            vc1.SetActive(false);
            dialogueCanvas.SetActive(true);
            playerMovement.enabled = false;
        }
    }
}
