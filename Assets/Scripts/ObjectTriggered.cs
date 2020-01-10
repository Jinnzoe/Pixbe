using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectTriggered : MonoBehaviour
{
    public GameManager gameManager;

    public EndLevel endLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.RestartLevel();
        }
        else if(collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(3);
        }
    }
}
