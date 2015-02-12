using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour 
{
	protected bool hasBeenHooked;

	[SerializeField]
	protected float mass;
	
	[SerializeField]
	protected string objectName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum PickupType
{
	fish,
	gold,
	trap
}
