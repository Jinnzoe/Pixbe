using UnityEngine;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    private bool isSlowmotioned;

    public AudioMixerSnapshot lowPassFilterE;
    public AudioMixerSnapshot lowPassFilterD;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isSlowmotioned)
            DoSlowmotion();
        else if (Input.GetMouseButtonDown(1) && isSlowmotioned)
            StopSlowmotion();

        if (Time.timeScale != 1 && !isSlowmotioned)
            StopSlowmotion();

        AudioFx();
    }

    void StopSlowmotion()
    {
        isSlowmotioned = false;
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    void DoSlowmotion()
    {
        isSlowmotioned = true;

        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public bool TimeState()
    {
        return isSlowmotioned;
    }

    public void ActiveSlowMo()
    {
        DoSlowmotion();
    }

    void AudioFx()
    {
        if(isSlowmotioned)
        {
            lowPassFilterE.TransitionTo(.001f);
        }
        else
            lowPassFilterD.TransitionTo(.001f);
    }
}
