using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Transform player;
    public bool right;
    public ParticleSystem bloodExplosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();

            if (transform.position.x - player.position.x < 0)
                right = true;
            else
                right = false;


            if (!right)
                speed *= -1;
            else
                speed *= 1;
        }
    }

    private void Update()
    {
        rb.velocity = new Vector3(speed * Time.unscaledDeltaTime, 0);
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
        else if (!collision.CompareTag("EndLevel"))
            Destroy(gameObject);
    }
}
