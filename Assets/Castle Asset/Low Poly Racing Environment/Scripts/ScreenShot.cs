using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public string imageName = "Lowpoly Racing Environment";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + imageName + ".png");
            Debug.Log(Application.persistentDataPath + "/" + imageName + ".png");
        }
    }
}
