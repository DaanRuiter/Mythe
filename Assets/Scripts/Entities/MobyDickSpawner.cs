using UnityEngine;
using System.Collections;

public class MobyDickSpawner : MonoBehaviour 
{
    public float minSpawnTime, maxSpawnTime;

	public GameObject moby;
	public bool mobyHasSpawned;

	void Start () 
	{
		mobyHasSpawned = false;
        float spawnTimeRange = Random.Range(minSpawnTime, maxSpawnTime);

		Invoke("SpawnHim", spawnTimeRange);
	}

	void SpawnHim()
	{
		Instantiate(moby, new Vector3(29, -20, 0), Quaternion.identity);
		mobyHasSpawned = true;
	}
}
