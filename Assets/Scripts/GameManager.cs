using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider life;
    public Slider dashTime;
    public Text timeTxt;
    public PlayerStats playerStats;
    public PlayerDash playerDash;
    //public TimeManager timeManager;
    public float levelId;
    public float time2R;
    private float tempTime;

    private bool slowmo, doubleJump;

    private void Start()
    {
        time2R = 60f;
        doubleJump = false;
        tempTime = PlayerPrefs.GetFloat("globalTime");

        if (tempTime != 0)
            time2R = PlayerPrefs.GetFloat("globalTime");

        dashTime.maxValue = playerDash.timeBDash;

    }

    // Update is called once per frame
    void Update()
    {
        life.value = playerStats.GetLife();
        time2R -= Time.deltaTime * 1.25f;
        timeTxt.text = time2R.ToString("F0") + "s";

        if(time2R <= 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }

        DashValue();
    }

    void DashValue()
    {

        dashTime.value = playerDash.GetDashTime();
    }

    /// <summary>
    /// read only
    /// </summary>
    /// <returns></returns>
    public bool GetDoubleJump()
    {
        return doubleJump;
    }

    public void ActiveDoubleJump()
    {
        doubleJump = true;
    }

    public void NextLevel(bool final)
    {
        if (!final)
            SceneManager.LoadScene((levelId + 1).ToString());
        else
        {
            PlayerPrefs.SetFloat("completed", 1);
            SceneManager.LoadScene("Win");
        }

        PlayerPrefs.SetFloat("globalTime", time2R);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelId.ToString());
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
