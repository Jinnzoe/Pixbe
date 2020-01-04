using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button hard;
    private float completed;

    private void Start()
    {
        completed = PlayerPrefs.GetFloat("completed");

        if (completed == 1)
            hard.interactable = true;
        else
            hard.interactable = false;
    }

    /// <summary>
    /// Hard?
    /// </summary>
    /// <param name="hard"></param>
    public void LoadScene(bool hard)
    {
        if (hard)
            PlayerPrefs.SetFloat("globalTime", 35);
        else
            PlayerPrefs.SetFloat("globalTime", 200);

        SceneManager.LoadScene("1");
    }

    public void Exit()
    {
        Debug.Log("Pussy");
        Application.Quit();
    }
}
