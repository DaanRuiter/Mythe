using UnityEngine;
using System.Collections;

public class SmallFish_Horizontal : FishPickup 
{	
	private bool _negativeMovement;

	protected override void Start() 
	{
		base.Start();

		startScale = transform.localScale.x;

		mass = 10;
		speedMultiplier = 0.1f;
		
		radiusX = 5;

		_negativeMovement = false;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{
		direction = new Vector2 (x, y);
		
		if(x >= radiusX)
		{
			_negativeMovement = true;
		}else if(x <= -radiusX)
		{
			_negativeMovement = false;
		}
		if(_negativeMovement)
		{
			scale.x = startScale;
			x -= speed;
		}else if(!_negativeMovement)
		{
			scale.x = -startScale;
			x += speed;
		}
		transform.position = basePosition + direction;

		transform.localScale = scale;
	}
}
