using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlanktonSpawner : MonoBehaviour
{
    [SerializeField]
    private float emissionFrequence = 1f;

    [SerializeField]
    private int minPlanktonParticles = 3;
    [SerializeField]
    private int maxPlanktonParticles = 50;

    [SerializeField]
    private Transform spawnRangeMin;
    [SerializeField]
    private Transform spawnRangeMax;

    [SerializeField]
    private GameObject PlanktonPrefab;

    void Start()
    {
        SpawnParticles();
        StartCoroutine(SpawnPlanktonParticles());
    }

    IEnumerator SpawnPlanktonParticles()
    {
        yield return new WaitForSecondsRealtime(emissionFrequence);
        SpawnParticles();
        StartCoroutine(SpawnPlanktonParticles());
    }

    private void SpawnParticles()
    {
        int randomParticleNumber = Random.Range(minPlanktonParticles, maxPlanktonParticles);

        for (int i = 0; i < randomParticleNumber; i++)
        {
            float randomXPosition = Random.Range(spawnRangeMin.position.x, spawnRangeMax.position.x);
            float randomYPosition = Random.Range(spawnRangeMin.position.y, spawnRangeMax.position.y);
            Vector3 randomSpawnPos = new Vector3 (randomXPosition, randomYPosition, 0);
            Instantiate(PlanktonPrefab, randomSpawnPos, Quaternion.identity);
        }
    }
}
