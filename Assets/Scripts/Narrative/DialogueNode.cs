using System;
using System.Collections.Generic;
using UnityEngine;


public enum DialogueOptionResult
{
    NEGATIVE,
    NEUTRAL,
    POSITIVE
}

[Serializable]
public class DialogueOption
{
    [Tooltip("Player's answer text for this option.")]
    public string text;

    [Tooltip("The dialogue node to jump to after choosing this option.")]
    public DialogueNode nextDialogueNode;

    public DialogueOptionResult result;
}


[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string npcText;
    public List<DialogueOption> playerChoices;
    public bool requireMinigame;
    public bool IsFinalNode
    {
        get {
            return playerChoices == null || playerChoices.Count == 0 || playerChoices.TrueForAll(c => c.nextDialogueNode == null);
        }
    }


    public DialogueNode(string npcText, List<DialogueOption> playerChoices)
    {
        this.npcText = npcText;
        this.playerChoices = playerChoices;
    }
}
