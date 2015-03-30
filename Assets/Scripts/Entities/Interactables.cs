using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour 
{
	protected bool hasBeenHooked;

	protected float speed;
	protected float mathSpeed;

	[SerializeField]
	protected float mass;

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
	
	protected virtual void FixedUpdate()
	{
		speed = speedMultiplier;
		mathSpeed += Time.deltaTime * speedMultiplier;

		if(hasBeenHooked)
		{
			folowPattern = false;
		}else
		{
			folowPattern = true;
		}

		if(folowPattern == true)
		{
			Movement();
		}
	}
	
	protected virtual void Movement()
	{

	}

    public void PickUp(Transform newParent = null)
    {
        if(newParent != null)
        {
            transform.parent = newParent;
            hasBeenHooked = true;
        }
    }
}