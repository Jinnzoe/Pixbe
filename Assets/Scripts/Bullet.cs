using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public ParticleSystem bloodExplosion;
    

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null)
        {
            PlayerStats player;

            player = collision.GetComponent<PlayerStats>();

            player.TakeDamage(.5f);
            Instantiate(bloodExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(collision.GetComponent<EnemyStats>() != null)
        {
            EnemyStats enemyStats;

            enemyStats = collision.GetComponent<EnemyStats>();

            enemyStats.TakeDamage(.5f);
            Instantiate(bloodExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("EndLevel"))
            Destroy(gameObject);
    }
}
