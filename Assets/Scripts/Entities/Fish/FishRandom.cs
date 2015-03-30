using UnityEngine;
using System.Collections;

public class FishRandom : FishPickup 
{
	private float switchDirection = 3;
	private float curTime = 0;

	protected override void Start ()
	{
		SetDir();
	}
	
	void SetDir ()
	{
		if (Random.value > .5) 
		{
			x = 0.5f * 0.5f * Random.value;
		}
		else {
			x = -0.5f * 0.5f * Random.value;
		}
		if (Random.value > .5) 
		{
			y = 0.5f * 0.5f * Random.value;
		}
		else {
			y = -0.5f * 0.5f * Random.value;
		}
	}
	
	protected override void FixedUpdate ()
	{
		base.FixedUpdate();
	}

	protected override void Movement()
	{
		if (curTime < switchDirection) 
		{
			curTime += 1 * Time.deltaTime;
		}
		else{
			SetDir();
			if (Random.value > .5) 
			{
				switchDirection += Random.value;
			}
			else {
				switchDirection -= Random.value;
			}
			if (switchDirection < 1) 
			{
				switchDirection = 1 + Random.value;
			}
			curTime = 0;
		}

		if(transform.position.x >= 29)
		{
			x = -0.05f;
		}else if(transform.position.x <= -29)
		{
			x = 0.05f;
		}else if(transform.position.y >= 5)
		{
			y = -0.05f;
		}else if(transform.position.y <= -19)
		{
			y = 0.05f;
		}

		direction += new Vector2(x,y);

		transform.position = direction;
	}
}