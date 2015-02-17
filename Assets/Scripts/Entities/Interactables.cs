using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour 
{
	protected bool hasBeenHooked;

	protected float speed;
	protected float mathSpeed;

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

	[SerializeField]
	protected float speedMultiplier;

	// Use this for initialization
	protected virtual void Start () 
	{
		hasBeenHooked = false;
	}

<<<<<<< HEAD
    public int GetPoints()
    {
        return points;
    }
=======
	protected virtual void FixedUpdate()
	{
		speed = speedMultiplier;
		mathSpeed += Time.deltaTime * speedMultiplier;
		
		if(!hasBeenHooked)
		{
			Movement();
		}
	}
	
	protected virtual void Movement()
	{
		
	}
>>>>>>> b31562559ebc2f5e219f8a65d1758c12fa62ea87
}


public enum PickupType
{
	none,
	fish,
	gold,
	trap
}
