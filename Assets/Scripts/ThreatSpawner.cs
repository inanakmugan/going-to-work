using UnityEngine;

public class ThreatSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnTransformOne;
    [SerializeField] Transform spawnTransformTwo;
    [SerializeField] GameObject[] Threats;

    //deneme amaçlıdır
    [SerializeField] float destroyOffset;

    void Start()
    {
        SpawnRandomThreats();
    }

    void SpawnRandomThreats()
    {
        GameObject getRandomObjectOne = GetRandomThreat();
        GameObject getRandomObjectTwo = GetRandomThreat();
        Instantiate(getRandomObjectOne, spawnTransformOne.position,
        Quaternion.identity);
        Instantiate(getRandomObjectTwo, spawnTransformTwo.position,
        Quaternion.identity);
    }

    GameObject GetRandomThreat()
    {
        if (Threats != null && Threats.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, Threats.Length);

            return Threats[randomIndex];
        }
        else
        {
            return null;
        }
    }
}
