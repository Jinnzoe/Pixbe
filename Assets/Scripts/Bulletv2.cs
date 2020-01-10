using UnityEngine;

public class Bulletv2 : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //Make damage
        }

        Destroy(gameObject);
    }
}
