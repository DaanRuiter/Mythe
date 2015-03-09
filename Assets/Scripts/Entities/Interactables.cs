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

    protected Vector2 basePosition;

	protected bool folowPattern;

	// Use this for initialization
	protected virtual void Start () 
	{
		hasBeenHooked = false;

		folowPattern = true;

        basePosition = transform.position;
	}

    public PickupType GetPickupType()
    {
        return type;
    }

    public int GetPoints()
    {
        return points;
    }

	protected virtual void FixedUpdate()
	{
		speed = speedMultiplier;
		mathSpeed += Time.deltaTime * speedMultiplier;

		if(folowPattern == true)
		{
			Movement();
		}

		if(!hasBeenHooked)
		{
			folowPattern = true;
		}
	}
	
	protected virtual void Movement()
	{
		
	}

    public void PickUp(Transform newParent)
    {
        transform.parent = newParent;
        hasBeenHooked = true;
    }
}


public enum PickupType
{
	none,
	fish,
	gold,
	trap
}
