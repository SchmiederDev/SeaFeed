using System.Collections;
using UnityEngine;

public class StandardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnObject;

    [SerializeField]
    private float firstSpawnTimeFrame = 1.5f;

    [SerializeField]
    private float spawnRate = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateFirst());
    }

    IEnumerator InstantiateFirst()
    {
        yield return new WaitForSeconds(firstSpawnTimeFrame);
        Instantiate(SpawnObject, transform.position, Quaternion.identity);
        StartCoroutine(InstantiateObjects());
    }

    IEnumerator InstantiateObjects()
    {
        yield return new WaitForSecondsRealtime(spawnRate);
        Instantiate(SpawnObject, transform.position, Quaternion.identity);
        StartCoroutine(InstantiateObjects());
    }
}
