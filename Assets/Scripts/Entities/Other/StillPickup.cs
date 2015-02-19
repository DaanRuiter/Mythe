using UnityEngine;
using System.Collections;

public class StillPickup : FishPickup 
{
	private float _rotateRange = -0.1f;
	
	protected override void Start() 
	{
		base.Start();

		speedMultiplier = 0.5f;

		radiusY = 1;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{
		direction = new Vector2(x, y);
		
		y = Mathf.Sin(mathSpeed) * radiusY;


		transform.Rotate(0,0,_rotateRange);

		/*if(transform.rotation.z >= 0.15)
		{

		}else if(transform.rotation.z <= )
		{

		}*/

		transform.position = basePosition + direction;
	}
}
