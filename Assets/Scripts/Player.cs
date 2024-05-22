using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float normalSpeed = .2f;
    [SerializeField] float slowSpeed = .01f;
    [SerializeField] float slowAnimationSpeed = .02f;


    [Header("Jump Settings")]
    [SerializeField] int maxJumpCount = 2;
    [SerializeField] int jumpCount = 0;
    [SerializeField] float AnimHeightLimit = 2.85f;
    [SerializeField] AudioClip jumpSFX;


    [Header("Boxcast Settings")]
    [SerializeField] Vector3 boxSize;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;


    //Cached References
    private Rigidbody playerRigidBody;
    private Animator playerAnimator;
    private Vector3 jumpInput;
    private float moveSpeed;
    AudioSource audioSource;


    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        //moveSpeed = normalSpeed;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            Jump();
        }
        UpdateAnimationState();
    }

    public void Jump()
    {
        jumpInput = Vector3.up * jumpForce;
        playerRigidBody.AddForce(jumpInput, ForceMode.Impulse);
        jumpCount--;
        audioSource.PlayOneShot(jumpSFX);
    }

    bool GroundCheck()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up,
        transform.rotation, maxDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = maxJumpCount;
        }
    }

    private void UpdateAnimationState()
    {
        if (transform.position.y > AnimHeightLimit)
        {
            playerAnimator.SetBool("Jump", true);

        }
        else if (transform.position.y < AnimHeightLimit)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
        }

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift) && GroundCheck())
        {
            SlowSpeed();
        }
        else
        {
            NormalSpeed();
        }
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }


    private void SlowSpeed()
    {
        moveSpeed = slowSpeed;
        playerAnimator.speed = slowAnimationSpeed;
    }


    private void NormalSpeed()
    {
        moveSpeed = normalSpeed;
        playerAnimator.speed = 1;
    }
}
