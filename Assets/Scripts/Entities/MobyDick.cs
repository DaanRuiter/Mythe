using UnityEngine;
using System.Collections;

public class MobyDick : MonoBehaviour 
{
	private float _blastTime;
	[SerializeField]
	private ParticleSystem _waterBlast;

	private Vector2 movement;

	private float _x;
	private float _y;
	private float _timer;

	public bool despawning;
	private bool _negativeMovement;

	void Start () 
	{
		_timer = Random.Range(4, 8);

		Invoke ("Despawn", Random.Range(10, 15));

		_x = transform.position.x;
		_y = transform.position.y;

		_negativeMovement = false;

		despawning = false;
	}
	
	void FixedUpdate () 
	{
		_timer -= Time.deltaTime;

		if(_timer <= 0)
		{
			WaterBlast();
		}

		if(_waterBlast.isPlaying == false && despawning == false)
		{
			SteeringBehaviour();
		}else if(despawning == true)
		{
			Despawn();
		}
	}

	void SteeringBehaviour()
	{
		movement = new Vector2(_x, _y);

		float borderX = 30f;

		if(_x <= -borderX)
		{
			_negativeMovement = false;
		}else if(_x >= borderX)
		{
			_negativeMovement = true;
		}
		if(_negativeMovement)
		{
			_x -= 0.5f;
		}else if(!_negativeMovement)
		{
			_x += 0.5f;
		}

		transform.position = movement;
	}

	void WaterBlast()
	{
		_waterBlast.Play();
		_timer = Random.Range(4, 8);
	}

	public void Despawn()
	{
		movement = new Vector2(_x, _y);

		despawning = true;
		_waterBlast.Stop(true);

		_y -= 0.2f;

		if(_y <= -35)
		{
			Destroy(this.gameObject);
		}

		transform.position = movement;
	}
}

