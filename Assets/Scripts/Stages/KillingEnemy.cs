using UnityEngine;

public class KillingEnemy : MonoBehaviour
{
    EnemyStats enemyStats;
    public EndLevel endLevel;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyStats.GetLife() <= 0)
        {
            endLevel.OpenDoor();
            enemyStats.gameObject.SetActive(false);
        }
    }
}
