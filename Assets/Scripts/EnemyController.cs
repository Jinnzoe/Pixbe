using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Components")]
    public Transform groundPoint;
    private Rigidbody2D rb;
    private EnemyAttacker enemyAttacker;

    [Header("Parameters")]
    public LayerMask groundMask;
    public float groundRadius;
    private Quaternion rotation;
    private bool isGround;

    public float movSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAttacker = GetComponent<EnemyAttacker>();

        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundMask);

        if(!enemyAttacker.PlayerNear())
        {
            Movement();
        }
    }

    void Movement()
    {
        if (isGround)
        {
            //transform.position += new Vector3(movSpeed * Time.deltaTime, 0);
            if (enemyAttacker.DirRotation())
                rb.velocity = new Vector3(-movSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector3(movSpeed, rb.velocity.y);
        }
        else
        {
            if (transform.rotation != rotation)
                transform.rotation = rotation;
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);

            movSpeed *= -1;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
    }
}
