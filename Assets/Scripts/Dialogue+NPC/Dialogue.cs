using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public TextMeshProUGUI speakername;
    public string speakernameinput;
    public GameObject dialogueCanvas;
    public PlayerMovement playerMovement;
    public GameObject vc1;

    private int index;

    public AudioSource talk;
    public AudioClip talksound;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        speakername.text = speakernameinput;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            talk.PlayOneShot(talksound);
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            vc1.SetActive(true);
            dialogueCanvas.SetActive(false);
            playerMovement.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
