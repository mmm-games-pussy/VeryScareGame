using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject objectToSpawn;

    private void Start()
    {
        SpawnRandom();
    }

    void SpawnRandom()
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null)
        {
            Debug.LogWarning("Не заданы точки спавна или объект для спавна.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(objectToSpawn, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}