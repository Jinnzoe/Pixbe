using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float life;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
    }

    public void TakeDamage(float amount)
    {
        life -= amount;
    }

    /// <summary>
    /// Read Only
    /// </summary>
    /// <returns></returns>
    public float GetLife()
    {
        return life;
    }
}
