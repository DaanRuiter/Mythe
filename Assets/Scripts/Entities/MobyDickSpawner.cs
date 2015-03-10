using UnityEngine;
using System.Collections;

public class MobyDickSpawner : MonoBehaviour 
{

	public GameObject moby;
	public bool mobyHasSpawned;

	void Start () 
	{
		mobyHasSpawned = false;
		float spawnTimeRange = Random.Range(2, 4);

		Invoke("SpawnHim", spawnTimeRange);

		Invoke("DespawnHim", spawnTimeRange + 4);
	}

	void SpawnHim()
	{
		Instantiate(moby, new Vector3(29, -20, 0), Quaternion.identity);
		mobyHasSpawned = true;
	}
	void DespawnHim()
	{
	}
}
