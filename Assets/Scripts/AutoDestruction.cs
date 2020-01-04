using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    public bool destroy;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        if (destroy)
            Destroy(gameObject, time);
    }
}
