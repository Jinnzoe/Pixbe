using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource powerUpSFx;
    public EndLevel endLevel;
    public EndLevel endLevelClone;

    public bool unlockDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.ActiveDoubleJump();
            BoxCollider2D bx = GetComponent<BoxCollider2D>();
            bx.enabled = false;
            powerUpSFx.Play();
            if (unlockDoor)
            {
                endLevel.OpenDoor();
                endLevelClone.OpenDoor();
            }
            Destroy(gameObject, .1f);
        }
    }
}
