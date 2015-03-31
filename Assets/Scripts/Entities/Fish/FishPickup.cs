using UnityEngine;
using System.Collections;

public class FishPickup : Interactables
{
    protected float radiusX;
    protected float radiusY;
    protected float x;
    protected float y;
    protected float startScale;
	
    protected Vector2 scale;
    protected Vector2 direction;

	//private bool spawnCheck;
	//private bool despawnCheck;

	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		//spawnCheck = Camera.main.GetComponent<MobyDickSpawner>().mobyHasSpawned;
		//despawnCheck = Camera.main.GetComponent<MobyDickSpawner>().mobyHasDespawned;

		/*if(spawnCheck == true)
		{
			folowPattern = false;
			MoveAway();
		}else if(despawnCheck == true)
		{
			MoveBack();
		}*/
	}

	/*protected virtual void MoveAway()
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

	protected virtual void MoveBack()
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
	}*/
}
