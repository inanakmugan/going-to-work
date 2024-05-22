using UnityEngine;

public class FallingThreat : MonoBehaviour, IThread
{
    //settings
    [SerializeField] Player player;
    [SerializeField] float detectionRange = 8f;
    [SerializeField] float resetTime = 2f;
    private bool isFalling = false;
    private Vector3 startPosition;
    public float distanceToPlayer;
    [SerializeField] float timeBeforeDestroy = 5f;

    private int damagePoint = 10;
    private Rigidbody rbody;
    public int DamagePoint { get => damagePoint; set => damagePoint = value; }

    //properties
    void Start()
    {
        startPosition = transform.position + (Vector3.up * 7f);
        player = FindObjectOfType<Player>();
        transform.position = startPosition;
        rbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        HandleSpawn();
    }

    private void HandleSpawn()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < detectionRange && !isFalling)
        {
            isFalling = true;
            rbody.isKinematic = false;
            Invoke("ResetPosition", resetTime);
        }

    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        isFalling = false;
        rbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerHealth = collision.gameObject.GetComponent<Health>();
        if (playerHealth)
        {
            playerHealth.DecreaseHealth(damagePoint);
            Destroy(gameObject);
        }
    }

    public void DestroyThreat()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}
