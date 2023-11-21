using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue;
    static public int DialogueStartNum; 
    static public int DialogueEndNum; 

    public Dialogue[] GetDialogue()
    {
        dialogue.line.x = DialogueStartNum;
        dialogue.line.y = DialogueEndNum;
        dialogue.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x,(int)dialogue.line.y);
        return dialogue.dialogues;
    }
}
