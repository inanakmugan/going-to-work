using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] GameObject backgroundPrefab;
    [SerializeField] float enviromentLength = 124.33f;
    [SerializeField] float spawnOffset = 5f;
    [SerializeField] Transform playerTransform;

    [SerializeField] Quaternion spawnRotation = Quaternion.Euler(0, -90, 0);

    [SerializeField] Vector3 spawnPosition;
    GameObject newSpawnedBackground;
    GameObject oldSpawnedBackground;

    bool hasSpawnedNextBackground = false;

    void Start()
    {
        spawnPosition = spawnPosition + Vector3.right * spawnOffset;
        SpawnBackground();
    }

    void Update()
    {
        CheckAndDestroyBackgrounds();
        if (!hasSpawnedNextBackground)
        {
            CheckForSpawnBackground();
        }
    }

    private void CheckAndDestroyBackgrounds()
    {
        if (oldSpawnedBackground != null && newSpawnedBackground.transform.position.x + enviromentLength / 2 < playerTransform.position.x)
        {
            Destroy(oldSpawnedBackground);
            oldSpawnedBackground = null;
        }

    }

    private void CheckForSpawnBackground()
    {
        if (newSpawnedBackground.transform.position.x + enviromentLength / 2 < playerTransform.position.x)
        {
            SpawnBackground();
        }

    }

    private void SpawnBackground()
    {
        oldSpawnedBackground = newSpawnedBackground;
        newSpawnedBackground = Instantiate(backgroundPrefab, spawnPosition, spawnRotation);
        newSpawnedBackground.transform.parent = transform;
        spawnPosition += Vector3.right * enviromentLength;
        hasSpawnedNextBackground = false;
    }
}
