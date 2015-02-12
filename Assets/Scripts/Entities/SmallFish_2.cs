using UnityEngine;
using System.Collections;

public class SmallFish_2 : FishPickup 
{
	private float _bounceSpeed;
	private float _bounce;

	private bool _negativeMovement;

	void Start() 
	{
		fishPoints = 10;

		radiusX = transform.position.x + 4f;
		radiusY = 0.5f;
		speedMultiplier = 0.25f;
		x = transform.position.x;

		_negativeMovement = false;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{
		y = transform.position.y + _bounce;

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
			x -= speed;
		}else if(!_negativeMovement)
		{
			x += speed;
		}

		_bounce = (Mathf.Sin(mathSpeed * 25)) * radiusY;

		transform.position = direction;
	}
}
