using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] Image healthDisplay;
    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;
    PlayerScore playerScore;

    //properties
    float health = 100f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerScore = GetComponent<PlayerScore>();

        UpdateHealthDisplay();
    }

    private void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            HandleDeath();
        }
    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.fillAmount = health / 100f;
    }

    public void DecreaseHealth(int pointToDecrease)
    {
        health -= pointToDecrease;
        UpdateHealthDisplay();
        audioSource.PlayOneShot(audioClip);
        //damage effect
        GetComponent<DamageEffect>().TakeDamage();
    }

    public void IncreaseHealth(int pointToIncrease)
    {
        if (health < 100)
        {
            health += pointToIncrease;
            UpdateHealthDisplay();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FallControl"))
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        Debug.Log("Player Died");
        playerScore.RegisterScore();
        SceneManager.LoadScene(2);
    }
}
