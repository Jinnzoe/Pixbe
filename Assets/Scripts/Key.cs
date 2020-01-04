using UnityEngine;

public class Key : MonoBehaviour
{
    public EndLevel endLevel;
    public AudioSource keySFx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            endLevel.OpenDoor();
            keySFx.Play();
            Destroy(gameObject, .02f);
        }
    }
}
