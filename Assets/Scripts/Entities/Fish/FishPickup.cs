﻿using UnityEngine;
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
	
	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;
	}

    public int GetPointWorth()
    {
        return points;
    }
}
