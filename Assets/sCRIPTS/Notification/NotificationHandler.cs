using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
    /// <summary>
    // This script handles inside mechanisam of the notification popup  //
    /// </summary>
    
    public Text nameText;                                           // Reference to the tittle text
    public Text dialogText;                                         // Reference to the message body text
    public GameObject notificationPopup;                            // Reference to the notification popup
    public Notification dialogue;                                   // Reference to the notification class

    private Queue<string> sentences;                                // Reference for the sentences in a popup. FIFO

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();                            // Initializing the sentences from the queue
        StartDialogue(dialogue);                                    // When popup enabled, dialog will be automatically played
        StartCoroutine(SelfDeactivate());                           // Start Coroutine for self deactivate 
    }

    public void StartDialogue(Notification dialogue)                // Start dialogue method
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

    public void DisplayNextSentence()                               // Display next sentence
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

    IEnumerator TypeSentence(string sentence)                       // Texts animation
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;        
        }
    }

    public void EndDialogue()                                       // End of the dialogue
    {
        notificationPopup.SetActive(false);
        Debug.Log("End of convacation");
    }

    IEnumerator SelfDeactivate()                                    // Seld deactivation timmer
    {
        yield return new WaitForSeconds(7);
       // notificationPopup.SetActive(false);
    }
}
