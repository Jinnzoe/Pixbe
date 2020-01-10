using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerController playerController;
    public float timeBDash;
    private float timeBDasher;
    public float dashSpeed;
    public float dashTime;
    private float dashTimer;
    private bool dashed;
    private bool dashEnabled;
    public AudioSource dashSFx;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.OnGround())
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0 && !dashed && dashEnabled)
            {
                dashEnabled = false;
                timeBDasher = 0;
                dashed = true;
                dashTimer = dashTime;
                dashSFx.Play();
            }
            if (dashed && dashTimer > 0)
            {
                dashTimer -= Time.deltaTime;
                Dash();
            }
        }
        if (timeBDasher < timeBDash)
            timeBDasher += Time.deltaTime;
        else
            dashEnabled = true;
    }

    /// <summary>
    /// Read Only
    /// </summary>
    /// <returns></returns>
    public float GetDashTime()
    {
        Debug.Log(timeBDasher);
        return timeBDasher;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dashed = false;
    }

    void Dash()
    {
        transform.position += transform.right * dashSpeed * Time.deltaTime;
    }

    void EnableDash()
    {
        dashed = playerController.OnGround();
    }
}
