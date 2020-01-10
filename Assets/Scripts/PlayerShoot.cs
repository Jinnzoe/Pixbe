using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public AudioSource shootSFx;

    public float timeBShoot;
    private float time2Wait;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && time2Wait <= 0)
        {
            time2Wait = timeBShoot;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            shootSFx.Play();
        }

        if (time2Wait > 0)
            time2Wait -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(bulletSpawn.position, .01f);
    }
}
