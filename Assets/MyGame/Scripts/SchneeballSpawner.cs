using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    [Header("Normal Snowball")]
    public GameObject normalSnowball;

    [Header("Dirty Snowballs (von leicht → schwer)")]
    public GameObject[] dirtySnowballStages;

    [Header("Chancen")]
    [Range(0f, 1f)]
    public float dirtySnowballChance = 0.3f;

    [Header("Spawn Speed")]
    public float startSpawnRate = 1.2f;
    public float minSpawnRate = 0.4f;
    public float spawnSpeedIncrease = 0.05f; // wie stark es schneller wird

    private float currentSpawnRate;
    private int lastSpeedIncreaseScore = 0;

    void Start()
    {
        currentSpawnRate = startSpawnRate;
        InvokeRepeating(nameof(SpawnSnowball), 0f, currentSpawnRate);
    }

    void SpawnSnowball()
    {
        // Prüfen ob Spawnrate angepasst werden muss
        UpdateSpawnSpeed();

        bool spawnDirty = Random.value < dirtySnowballChance;

        GameObject snowballToSpawn = spawnDirty
            ? GetDirtySnowballForScore()
            : normalSnowball;

        Instantiate(snowballToSpawn, transform.position, Quaternion.identity);
    }

    void UpdateSpawnSpeed()
    {
        int score = ScoreManager.Instance.CurrentScore;

        // Alle 5 Punkte schneller werden
        if (score >= lastSpeedIncreaseScore + 5)
        {
            lastSpeedIncreaseScore = score;

            currentSpawnRate = Mathf.Max(
                minSpawnRate,
                currentSpawnRate - spawnSpeedIncrease
            );

            CancelInvoke(nameof(SpawnSnowball));
            InvokeRepeating(nameof(SpawnSnowball), 0f, currentSpawnRate);
        }
    }

    GameObject GetDirtySnowballForScore()
    {
        int score = ScoreManager.Instance.CurrentScore;

        // Wie viele Stufen sind freigeschaltet?
        int unlockedStages = 1;

        if (score >= 10) unlockedStages = 2;
        if (score >= 20) unlockedStages = 3;

        unlockedStages = Mathf.Clamp(unlockedStages, 1, dirtySnowballStages.Length);

        int index = Random.Range(0, unlockedStages);
        return dirtySnowballStages[index];
    }
}
