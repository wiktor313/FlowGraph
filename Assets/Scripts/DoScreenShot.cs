using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class NewBehaviourScript : MonoBehaviour
{

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.P) && !EventSystem.current.currentSelectedGameObject)
        {
           TakeScreenshot();
           StartCoroutine(WaitForOneFrame());
        }
    }

    void TakeScreenshot()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>().enabled = false;
        string folderPath = Application.dataPath + "/Screenshots/";

        if (!System.IO.Directory.Exists(folderPath))
            System.IO.Directory.CreateDirectory(folderPath);

        var screenshotName =
                                "Diagram_" +
                                System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
                                ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);
        System.Threading.Thread.Sleep(100);
    }
    IEnumerator WaitForOneFrame()
    {
        yield return null;
        Debug.Log("Po jednej klatce oczekiwania.");
        GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>().enabled = true;
    }
}
