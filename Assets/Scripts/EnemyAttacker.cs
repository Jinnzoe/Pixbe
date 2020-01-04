using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [Header("Components")]
    public Transform gun;
    public Transform player;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public AudioSource shootSFx;

    [Header("Parameters")]
    public float lookRadius;
    public LayerMask playerMask;
    private bool shooted;
    private float tBShoot;
    
    private bool playerNear;
    [SerializeField]
    private bool right;

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, lookRadius, playerMask);
        player = GameObject.Find("Player").GetComponent<Transform>();

        Direction();
        Shoot();
    }

    public bool PlayerNear()
    {
        return playerNear;
    }

    void Direction()
    {
        if (playerNear)
        {
            if (transform.position.x - player.position.x > 0)
            {
                right = true;
                Rotate(180);
            }
            else
            {
                right = false;
                Rotate(0);

            }
        }
    }

    public bool DirRotation()
    {
        return right;
    }

    void Rotate(float yRotation)
    {
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void Shoot()
    {
        if (playerNear && !shooted)
        {
            shooted = true;
            shootSFx.Play();
            StartCoroutine(SpawnBullet());
        }
    }

    public void MenuShoot()
    {
        shooted = true;
        shootSFx.Play();
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
        tBShoot = Random.Range(.5f, 3f);
        yield return new WaitForSeconds(tBShoot);

        shooted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
