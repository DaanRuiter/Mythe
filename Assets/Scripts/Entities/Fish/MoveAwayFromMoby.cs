using UnityEngine;
using System.Collections;

public class MoveAwayFromMoby : FishPickup 
{

	protected override void FixedUpdate () 
	{
		base.FixedUpdate();

		spawnCheck = Camera.main.GetComponent<MobyDickSpawner>().mobyHasSpawned;
		despawnCheck = Camera.main.GetComponent<MobyDickSpawner>().mobyHasDespawned;
		
		if(spawnCheck == true)
		{
			folowPattern = false;
			MoveAway();
		}else if(despawnCheck == true)
		{
			MoveBack();
		}
		
		if(!despawnCheck && !spawnCheck)
		{
			folowPattern = true;
		}
	}
	void MoveAway()
	{
		if(transform.position.x <= 0 && transform.position.x >= -40f)
		{
			x = -0.3f;
		}else if(transform.position.x >= 0 && transform.position.x <= 40f)
		{
			x = 0.3f;
		}else
		{
			x = 0f;
		}
		
		direction = new Vector2(x, 0);
		
		transform.position += new Vector3(direction.x, direction.y, 0);
	}
	
	void MoveBack()
	{
		if(transform.position.x <= basePosition.x)
		{
			x = 0.3f;
		}else if(transform.position.x >= basePosition.x)
		{
			x = -0.3f;
		}
		
		direction = new Vector2(x, 0);
		
		transform.position += new Vector3(direction.x, direction.y, 0);
	}
}
