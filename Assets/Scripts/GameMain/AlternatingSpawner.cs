using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnObject;

    [SerializeField]
    private float firstSpawnTimeFrame = 1.5f;

    [SerializeField]
    private float spawnRate = 3f;

    [SerializeField]    
    private float upperBound;

    [SerializeField]
    private float lowerBound;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPosition = GetRandomYPosition();
        StartCoroutine(InstantiateFirst(randomSpawnPosition));
    }

    IEnumerator InstantiateFirst(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(firstSpawnTimeFrame);
        Instantiate(SpawnObject, spawnPosition, Quaternion.identity);
        Vector3 randomSpawnPosition = GetRandomYPosition();
        StartCoroutine(InstantiateObjects(randomSpawnPosition));
    }

    IEnumerator InstantiateObjects(Vector3 spawnPosition)
    {
        yield return new WaitForSecondsRealtime(spawnRate);
        Instantiate(SpawnObject, spawnPosition, Quaternion.identity);
        Vector3 randomSpawnPosition = GetRandomYPosition();
        StartCoroutine(InstantiateObjects(randomSpawnPosition));
    }

    private Vector3 GetRandomYPosition()
    {
        float randomY = Random.Range(lowerBound, upperBound);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        return spawnPosition;
    }
}
