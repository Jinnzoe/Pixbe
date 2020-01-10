using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public TimeManager timeManager;
    public float levelId;

    // Start is called before the first frame update
    void Awake()
    {
        timeManager.DoSlowmotion();
    }

    public float GetLevel()
    {
        return levelId;
    }
}
