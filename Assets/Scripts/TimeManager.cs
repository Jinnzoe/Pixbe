using UnityEngine;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public bool isSlowed;

    public AudioMixerSnapshot lowPassFilterE;
    public AudioMixerSnapshot lowPassFilterD;

    void Update()
    {
        Time.timeScale += (.5f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        
        if (Time.timeScale > .5f)
            isSlowed = false;

        if (Input.GetMouseButtonDown(1))
        {
            DoSlowmotion();
        }
        //AudioFx();
    }

    public void DoSlowmotion()
    {
        isSlowed = true;
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public bool TimeState()
    {
        return isSlowed;
    }
    
    void AudioFx()
    {
        if(isSlowed)
        {
            lowPassFilterE.TransitionTo(.001f);
        }
        else
            lowPassFilterD.TransitionTo(.001f);
    }
}
