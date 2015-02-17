using UnityEngine;
using System.Collections;

public class SmallFish_Circle : FishPickup
{
	private float _angle;


	protected override void Start() 
	{
		base.Start();

		mass = 10;
		speedMultiplier = 1;

		radiusX = 5;
		radiusY = 5;
	}
	
	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}

	protected override void Movement()
	{
		direction = new Vector2(x, y);

		_angle = Mathf.Atan2(direction.y, direction.x) * (180 / Mathf.PI) + 90;
		transform.rotation = Quaternion.Euler(0, 0, _angle);

		x = Mathf.Cos(mathSpeed) * radiusX;
		y = Mathf.Sin(mathSpeed) * radiusY;

		transform.position = basePosition + direction;
	}
}
