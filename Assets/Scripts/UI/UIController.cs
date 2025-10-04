using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public NarrativeController narrativeController;

    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI[] textOptions;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDialogueNode(DialogueNode node)
    {
        Debug.Log(node.npcText);
        textQuestion.text = node.npcText;
        for (int i = 0; i < node.playerChoices.Count; i++)
        {
            textOptions[i].text = node.playerChoices[i].text;
        }
    }

    public void SelectTextOption(int index)
    {
        textOptions[index].color = Color.white;
    }


    public void SelectOption1()
    {
        narrativeController.ProgressDialogue(0);
    }

    public void SelectOption2()
    {
        narrativeController.ProgressDialogue(1);
    }

    public void SelectOption3()
    {
        narrativeController.ProgressDialogue(2);
    }
}
