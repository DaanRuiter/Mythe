using UnityEngine;
using System.Collections;

public class SmallFish : Interactable
{
	private float _x;
	private float _y;
	private float _angle;
	private Vector2 _direction;

	protected override void Start () 
	{
		speed = 1;
	}
	
	protected override void Update () 
	{
		base.Update();
	}

	protected override void Movement()
	{
		_direction = new Vector2(_x, _y);

		_angle = Mathf.Atan2(_direction.y, _direction.x) * (180 / Mathf.PI) + 90;

		timeCounter += Time.deltaTime * speed;
		
		_x = Mathf.Cos(timeCounter);
		_y = Mathf.Sin(timeCounter);

		_direction.Normalize();

		transform.rotation = Quaternion.Euler(0, 0, _angle);

		transform.position = _direction;
	}
}
