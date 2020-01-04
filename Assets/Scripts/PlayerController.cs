using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private Transform player;
    private Rigidbody2D rb;
    private GameManager gameManager;

    [Header("Movement Parameters")]
    public float horizontalSpeed;
    private float xSpeed, ySpeed;

    [Header("Jump Parameters")]
    public Transform jumpPoint;
    public float jumpForce;
    public float jumpRadius;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool hasJump;
    private bool doubleJumpState;

    [Header("Visaul Fx")]
    public TimeManager timeManager;
    public PostProcessVolume activeVolume;
    private ChromaticAberration cA;
    private Vignette vignette;
    private ColorGrading cG;

    [Header("Sound Fx")]
    public AudioSource jumpSFx;
    public AudioSource dashSFx;
    public AudioSource powerUpSFx;
    public AudioSource coinPickupSFx;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (doubleJumpState)
            DoubleJump();
        else
            Jump();

        IsGrounded();
        ApplyFx();

        doubleJumpState = gameManager.GetDoubleJump();
    }

    public void RestJump(float amount)
    {
        if (jumpForce > 1)
            jumpForce -= amount;
    }

    void ApplyFx()
    {
        activeVolume.profile.TryGetSettings(out cA);
        activeVolume.profile.TryGetSettings(out vignette);
        activeVolume.profile.TryGetSettings(out cG);

        if (timeManager.TimeState())
        {
            if(cA.intensity.value < 1)
                cA.intensity.value += .25f;
            if (vignette.intensity.value < .5f)
                vignette.intensity.value += .05f;

            if (cG.temperature.value < 80)
                cG.temperature.value += 10;
        }
        else
        {
            if (cA.intensity.value > 0)
                cA.intensity.value -= Time.deltaTime;
            if(vignette.intensity.value > 0)
                vignette.intensity.value -= Time.deltaTime;

            if (cG.temperature.value > 0)
            {
                cG.temperature.value -= 5;
            }
        }
    }

    void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(jumpPoint.position, jumpRadius, groundMask);

        if (isGrounded)
            hasJump = false;
    }

    void DoubleJump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || !hasJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (!hasJump && !isGrounded)
                hasJump = true;
            jumpSFx.Play();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Movement()
    {
        xSpeed = Input.GetAxis("Horizontal") * horizontalSpeed;

        player.position += new Vector3(xSpeed * Time.deltaTime, ySpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(jumpPoint.position, jumpRadius);
    }
}
