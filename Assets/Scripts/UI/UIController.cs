using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public NarrativeController narrativeController;

    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI[] textOptions;
    public TextMeshProUGUI rizzCounter;

    private Color defaultColor = Color.red;
    private Color[] optionColors = { Color.blue, Color.green, Color.yellow };

    public RawImage characterImage;
    public Texture negativeResultSprite;
    public Texture neutralResultSprite;
    public Texture positiveResultSprite;
 

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
        for (int i = 0; i < textOptions.Length; i++)
        {
            TextMeshProUGUI textMesh = textOptions[i];
            
            if (i < node.playerChoices.Count)
            {
                textMesh.gameObject.SetActive(true);
                textMesh.text = node.playerChoices[i].text;

                Button textMeshButton = textMesh.GetComponent<Button>();

                
                if (node.requireMinigame)
                {
                    textMesh.color = optionColors[i];
                    textMeshButton.enabled = false;
                } else
                {
                    textMesh.color = defaultColor;
                    textMeshButton.enabled = true;
                }
                
                
            } else
            {
                textMesh.gameObject.SetActive(false);
            }
            
            
        }
    }

    public void ShowDialogResult(DialogueOptionResult result)
    {
        switch (result)
        {
            case DialogueOptionResult.NEGATIVE:
                characterImage.texture = negativeResultSprite;
                break;
            case DialogueOptionResult.NEUTRAL:
                characterImage.texture = neutralResultSprite;
                break;
            case DialogueOptionResult.POSITIVE:
                characterImage.texture = positiveResultSprite;
                break;
        }
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

    public void UpdateRizzCounter(int rizzScore)
    {
        rizzCounter.text = "Current rizz: " + rizzScore.ToString();
    }
}
