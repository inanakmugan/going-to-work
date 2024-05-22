using UnityEngine;

public class StaticThread : MonoBehaviour, IThread
{
    private int damagePoint = 10;
    public int DamagePoint { get => damagePoint; set => damagePoint = value; }

    public void DestroyThreat()
    {
        Destroy(gameObject);
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


}
