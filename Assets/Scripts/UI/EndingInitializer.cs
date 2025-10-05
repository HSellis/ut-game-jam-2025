using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingInitializer : MonoBehaviour
{
    public NarrativeController narrativeController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        narrativeController = NarrativeController.Instance;
        Debug.Log(narrativeController);
        string target = narrativeController.GetEndingPanelName();

        Debug.Log(target);
        Debug.Log(GameObject.Find(target));
        //var toShow = GameObject.Find(target);
        //toShow.SetActive(true);

        GameObject panel = null;
        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            var t = root.GetComponentsInChildren<Transform>(true)
                        .FirstOrDefault(x => x.name == target);
            if (t != null)
            {
                panel = t.gameObject;
                break;
            }
        }

        panel.SetActive(true);

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
