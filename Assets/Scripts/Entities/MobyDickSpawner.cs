using UnityEngine;
using System.Collections;

public class MobyDickSpawner : MonoBehaviour
{
    public GameObject moby;
    private GameObject a;
    public bool mobyHasSpawned;
    public bool mobyHasDespawned;

    void Start()
    {
        mobyHasSpawned = false;
        mobyHasDespawned = false;
        float spawnTimeRange = Random.Range(2, 4);

        Invoke("SpawnHim", spawnTimeRange);
    }

    void Update()
    {
        if (a != null)
        {
            DespawnHim();
        }
        else
        {
            mobyHasDespawned = false;
            mobyHasSpawned = false;
        }
    }

    void SpawnHim()
    {
        a = Instantiate(moby, new Vector3(35, -20, 0), Quaternion.identity) as GameObject;
        mobyHasSpawned = true;
    }
    void DespawnHim()
    {
        if (a.GetComponent<MobyDick>().despawning == true)
        {
            mobyHasSpawned = false;
            mobyHasDespawned = true;
        }
    }
}