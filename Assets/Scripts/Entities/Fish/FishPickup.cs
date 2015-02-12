using UnityEngine;
using System.Collections;

public class FishPickup : MonoBehaviour 
{
	protected float speed;
	protected float mathSpeed;
	protected float radiusX;
	protected float radiusY;
	protected float x;
	protected float y;

	protected bool hasBeenHooked;

#region Serialized variables
	[SerializeField]
	protected float speedMultiplier;
	[SerializeField]
	protected float mass;

	[SerializeField]
	protected string fishName;

	[SerializeField]
	protected int fishPoints;
#endregion

	protected Vector2 direction;

	protected virtual void Start()
	{
		hasBeenHooked = false;
	}

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
}
