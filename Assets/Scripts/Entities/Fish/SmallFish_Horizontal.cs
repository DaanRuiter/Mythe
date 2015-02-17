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

>>>>>>> b31562559ebc2f5e219f8a65d1758c12fa62ea87
		mass = 10;
		
		radiusX = transform.position.x + 8;

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
