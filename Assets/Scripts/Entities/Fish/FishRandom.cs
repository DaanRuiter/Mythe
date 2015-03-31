using UnityEngine;
using System.Collections;

public class FishRandom : FishPickup 
{
	private float switchDirection = 3;
	private float curTime = 0;

	protected override void Start ()
	{
		base.Start();
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

		float angle = Mathf.Atan2(direction.y - this.transform.position.y, direction.x - this.transform.position.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);

		float localScale = transform.localScale.y;

		if(transform.rotation.z *360 >= 270)
		{
			transform.localScale = new Vector3(startScale,-startScale,1);
		}else
		{
			transform.localScale = new Vector3(startScale,startScale,1);
		}

		Debug.Log(localScale);

		transform.position = direction;


		Debug.Log (transform.rotation.z * 360);
	}
}