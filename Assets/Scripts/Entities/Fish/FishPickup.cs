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

	public bool spawnCheck;
    public bool checkMoby;
	public bool despawnCheck;

	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;

	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

<<<<<<< HEAD
        if(checkMoby)
        {
            spawnCheck = Camera.main.GetComponent<MobyDickSpawner>().mobyHasSpawned;
        }
=======

>>>>>>> c165bede37606c858068bad1cb4531d0c5886457
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
