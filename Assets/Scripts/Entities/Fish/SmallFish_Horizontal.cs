using UnityEngine;
using System.Collections;

public class SmallFish_Horizontal : FishPickup 
{	
	private bool _negativeMovement;

	protected override void Start() 
	{
		base.Start();

		startScale = transform.localScale.x;
<<<<<<< HEAD
=======

>>>>>>> 41cbbe2e7efc9cbd46cbaa8315f0a62c305073d3
		mass = 10;

		speedMultiplier = 0.25f;

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
