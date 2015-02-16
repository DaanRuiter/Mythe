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
		fishPoints = 10;
		speedMultiplier = 0.035f;
>>>>>>> origin/master
		mass = 10;
		speedMultiplier = 0.1f;
		
		radiusX = transform.position.x + 12;

		x = transform.position.x;
		y = transform.position.y;

		_negativeMovement = false;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{
		direction = new Vector2 (x, y);
		
		if(transform.position.x >= radiusX)
		{
			_negativeMovement = true;
		}else if(transform.position.x <= -radiusX)
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
		transform.position = direction;

		transform.localScale = scale;
	}
}
