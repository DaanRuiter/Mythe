using UnityEngine;
using System.Collections;

public class StillPickup : FishPickup 
{
	private float _rotateRange;
	
	protected override void Start() 
	{
		base.Start();

		speedMultiplier = 1;

		radiusY = 2;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{
		direction = new Vector2(x, y);
		
		y = Mathf.Sin(mathSpeed) * radiusY;

		if(direction.y >= 0)
		{
			_rotateRange = 0.5f;
		}else if(direction.y <= 0)
		{
			_rotateRange = -0.5f;
		}

		transform.position = basePosition + direction;

		transform.Rotate(0,0,_rotateRange);
	}
}
