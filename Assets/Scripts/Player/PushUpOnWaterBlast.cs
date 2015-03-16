using UnityEngine;
using System.Collections;

public class PushUpOnWaterBlast : MonoBehaviour {

    private PlayerController pc;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

	public void Blast()
    {
        pc.SetActive(false);
    }

    private void EndBlast()
    {
        pc.SetActive(true);
    }
}
