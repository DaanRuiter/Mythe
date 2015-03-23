using UnityEngine;
using System.Collections;

public class MobyDickSpawner : MonoBehaviour 
{
	public GameObject prefabMoby;
	private GameObject newMoby;
	
	public bool mobyHasSpawned;
	public bool mobyHasDespawned;

	[SerializeField]
	private float spawnTimeMin;
	[SerializeField]
	private float spawnTimeMax;

	void Start () 
	{
		mobyHasSpawned = false;
		mobyHasDespawned = false;
		float spawnTimeRange = Random.Range(spawnTimeMin, spawnTimeMax);

		Invoke("SpawnHim", spawnTimeRange);
	}

	void Update()
	{
		if(newMoby != null)
		{
			DespawnHim();
		}else
		{
			mobyHasDespawned = false;
			mobyHasSpawned = false;
		}
	}

	void SpawnHim()
	{
		newMoby = Instantiate(prefabMoby, new Vector3(29, -15, 0), Quaternion.identity) as GameObject;
		mobyHasSpawned = true;
	}
	void DespawnHim()
	{
		if(newMoby.GetComponent<MobyDick>().despawning == true)
		{
			mobyHasSpawned = false;
			mobyHasDespawned = true;
		}
	}
}
