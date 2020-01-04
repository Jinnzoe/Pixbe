using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Range(0,3)]
    private float life;
    PlayerController player;
    public AudioSource hurtSFx;
    public GameManager gameManager;

    private void Start()
    {
        life = 3;
        player = GetComponent<PlayerController>();
    }

    /// <summary>
    /// Damage will be .5f or 0f
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        life -= damage;
        player.RestJump(damage);
        hurtSFx.Play();

        if(life <= 0)
        {
            gameManager.RestartLevel();
        }
    }

    public float GetLife()
    {
        return life;
    }
}
