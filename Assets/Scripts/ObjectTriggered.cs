using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectTriggered : MonoBehaviour
{
    public GameManager gameManager;

    //cases to complete the level
    public bool killingEnemy;
    private bool enemyKilled;
    public EndLevel endLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.RestartLevel();
        }
        else if (collision.CompareTag("Enemy"))
        {
            if (gameManager != null)
                endLevel.OpenDoor();

            
            else
                Debug.Log("Final Level");
        }
    }
}
