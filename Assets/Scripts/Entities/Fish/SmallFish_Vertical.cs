using UnityEngine;
using System.Collections;

public class SmallFish_Vertical : FishPickup 
{

	private bool _negativeMovement;
	
	protected override void Start() 
	{
		base.Start();
		
		fishPoints = 10;
		mass = 10;
<<<<<<< HEAD:Assets/Scripts/Entities/Fish/SmallFish_2.cs

		radiusX = transform.position.x + 4f;
		radiusY = 0.5f;
=======
>>>>>>> d1c82e4bb694c1003d819726848045711f0b26fd:Assets/Scripts/Entities/Fish/SmallFish_Vertical.cs
		speedMultiplier = 0.25f;

		radiusY = transform.position.x + 5;
		
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
		
		if(transform.position.y >= radiusY)
		{
			_negativeMovement = true;
		}else if(transform.position.y <= -radiusY)
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
<<<<<<< HEAD:Assets/Scripts/Entities/Fish/SmallFish_2.cs

		_bounce = (Mathf.Sin(mathSpeed * 25)) * radiusY;

=======
>>>>>>> d1c82e4bb694c1003d819726848045711f0b26fd:Assets/Scripts/Entities/Fish/SmallFish_Vertical.cs
		transform.position = direction;

		transform.localScale = scale;
	}
}
