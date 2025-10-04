using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DialogueOption
{
    [Tooltip("Player's answer text for this option.")]
    public string text;

    [Tooltip("The dialogue node to jump to after choosing this option.")]
    public DialogueNode nextDialogueNode;
}


[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string npcText;
    public List<DialogueOption> playerChoices;
    public bool requireMinigame;

    public DialogueNode(string npcText, List<DialogueOption> playerChoices)
    {
        this.npcText = npcText;
        this.playerChoices = playerChoices;
    }
}
