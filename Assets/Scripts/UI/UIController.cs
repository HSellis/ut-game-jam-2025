using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        textQuestion.text = node.npcText;
        for (int i = 0; i < node.playerChoices.Count; i++)
        {
            TextMeshProUGUI textMesh = textOptions[i];
            textMesh.text = node.playerChoices[i].text;

            Button textMeshButton = textMesh.GetComponent<Button>();
            textMeshButton.interactable = !node.requireMinigame;
        }
    }

    public void SelectTextOption(int index)
    {
        Debug.Log("Seletce");
        TextMeshProUGUI textMesh = textOptions[index];
        Button textMeshButton = textMesh.GetComponent<Button>();
        
    }


    public void SelectOption1()
    {
        narrativeController.SelectDialogueOption(0);
    }

    public void SelectOption2()
    {
        narrativeController.SelectDialogueOption(1);
    }

    public void SelectOption3()
    {
        narrativeController.SelectDialogueOption(2);
    }
}
