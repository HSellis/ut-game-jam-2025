using UnityEngine;

public class EndingInitializer : MonoBehaviour
{
    public NarrativeController narrativeController;

    public GameObject badEndingPanel;
    public GameObject NeutralEndingPanel;
    public GameObject goodEndingPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        narrativeController = NarrativeController.Instance;
        int endingNumber = narrativeController.GetEndingNumber();
        switch (endingNumber)
        {
            case 0:
                badEndingPanel.SetActive(true);
                break;
            case 1:
                NeutralEndingPanel.SetActive(true);
                break;
            case 2:
                goodEndingPanel.SetActive(true);
                break;
        }

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
