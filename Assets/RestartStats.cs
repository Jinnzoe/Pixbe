using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("completed", 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F11))
        {
            ScreenCapture.CaptureScreenshot("Assets/screenshoot.png", 4);
            Debug.Log("Captured");
        }
    }
}
