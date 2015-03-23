using UnityEngine;
using System.Collections;

public class StillPickup : FishPickup 
{
	private float _rotateRange;
	
	protected override void Start() 
	{
		base.Start();

		speedMultiplier = 0.5f;

		_rotateRange = Random.Range(0.05f, 0.35f);
		if(_rotateRange > 0.2f)
		{
			_rotateRange = (_rotateRange*-1)/2;
		}

	}

	protected override void FixedUpdate () 
	{
		base.FixedUpdate();
	}
	
	protected override void Movement()
	{

		transform.Rotate(0,0,_rotateRange);

		if(transform.rotation.z >= 0.15f)
		{
			_rotateRange -= _rotateRange * 2;
		}else if(transform.rotation.z <= -0.15f)
		{
			_rotateRange -= _rotateRange * 2;
		}
	}
}
