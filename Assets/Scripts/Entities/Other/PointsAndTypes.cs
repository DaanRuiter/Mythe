using UnityEngine;
using System.Collections;

public class PointsAndTypes : MonoBehaviour 
{
	[SerializeField]
	public PickupType type;

	[SerializeField]
	public int points;

	public PickupType GetPickupType()
	{
		return type;
	}
	
	public int GetPoints()
	{
		return points;
	}
}

public enum PickupType
{
	fish,
	gold,
	trap
}