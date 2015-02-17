using UnityEngine;
using System.Collections;

public class SmallFish_Vertical : FishPickup 
{

	private bool _negativeMovement;
	
	protected override void Start() 
	{
		base.Start();

<<<<<<< HEAD
		speedMultiplier = 0.25f;

		radiusY = transform.position.y + 5;
		
		x = transform.position.x;
		y = transform.position.y;
		
=======
		speedMultiplier = 0.2f;

		radiusY = 5;

>>>>>>> 41cbbe2e7efc9cbd46cbaa8315f0a62c305073d3
		_negativeMovement = false;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{
		direction = new Vector2 (x, y);

		if(y >= radiusY)
		{
			_negativeMovement = true;
		}else if(y <= -radiusY)
		{
			_negativeMovement = false;
		}
		if(_negativeMovement)
		{
			scale.x = startScale;
			y -= speed;
		}else if(!_negativeMovement)
		{
			scale.x = -startScale;
			y += speed;
		}
		
		transform.position = basePosition + direction;

		transform.localScale = scale;
	}
}
