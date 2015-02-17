using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour 
{
	protected bool hasBeenHooked;

	[SerializeField]
	protected PickupType type;

	[SerializeField]
	protected PickupType secondaryType;

	[SerializeField]
	protected float mass;
	
	[SerializeField]
	protected string objectName;

	[SerializeField]
	protected int points;

	[SerializeField]
	protected int secondaryPoints;

	// Use this for initialization
	protected virtual void Start () 
	{
		hasBeenHooked = false;
	}

    public int GetPoints()
    {
        return points;
    }
}

public enum PickupType
{
	none,
	fish,
	gold,
	trap
}
