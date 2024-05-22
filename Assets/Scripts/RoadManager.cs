using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] GameObject roadPrefab;
    [SerializeField] Transform player;
    [SerializeField] float roadLength = 10f;
    [SerializeField] float playerTriggerDistance = 20f;
    [SerializeField] Vector3 spawnPosition = Vector3.zero;

    void Start()
    {
        SpawnRoad();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, spawnPosition) < playerTriggerDistance)
        {
            SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        Instantiate(roadPrefab, spawnPosition, Quaternion.identity);
        spawnPosition += Vector3.right * roadLength;
    }
}
