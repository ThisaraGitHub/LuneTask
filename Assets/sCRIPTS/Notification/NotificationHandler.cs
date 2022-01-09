using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public GameObject notificationPopup;
    //public GameObject activateNextInstruction;
    public Notification dialogue;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue(dialogue);
        StartCoroutine(SelfDeactivate());
    }

    public void StartDialogue(Notification dialogue)
    {
        notificationPopup.SetActive(true);
        Debug.Log("starting convacation" + dialogue.name);
        sentences.Clear();

        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
           
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
            
        }
    }

    public void EndDialogue()
    {
        notificationPopup.SetActive(false);
        Debug.Log("End of convacation");
    }

    IEnumerator SelfDeactivate()
    {

        yield return new WaitForSeconds(7);
       // notificationPopup.SetActive(false);
    }
}
