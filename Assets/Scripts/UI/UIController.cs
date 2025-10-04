using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
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

    public void SelectTextOption(int index)
    {
        textOptions[index].color = Color.white;
    }
}
