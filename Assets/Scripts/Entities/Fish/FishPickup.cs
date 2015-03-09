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

<<<<<<< HEAD
=======
	public bool spawnCheck;

>>>>>>> 7958aaa680f636006203b8e99a0d7377f2028384
	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		spawnCheck = Camera.main.GetComponent<MobyDickSpawner>().mobyHasSpawned;

		if(spawnCheck == true)
		{
			folowPattern = false;
			MoveAway();
		}
	}

	protected virtual void MoveAway()
	{
		direction = new Vector2(x, y);

		float checkScreenHalf;
		checkScreenHalf = Screen.width / 2;
		if(transform.position.x > checkScreenHalf)
		{
			x -= 0.25f;
		}else if(transform.position.x < checkScreenHalf)
		{
			x += 0.25f;
		}

		transform.position = direction;
	}


    public int GetPointWorth()
    {
        return points;
	}
}
