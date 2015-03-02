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

	private bool _negativeMovement;

	void Start () 
	{
		_blastTime = Random.Range(1,6);
		Invoke("WaterBlast", _blastTime);

		_x = transform.position.x;
		_y = transform.position.y;

		_negativeMovement = false;
	}
	
	void Update () 
	{
		if(_waterBlast.isPlaying == false)
		{
			SteeringBehaviour();
		}else 
		{
			sendCollision();
			Debug.DrawLine(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y +50) , Color.green, _waterBlast.duration);
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
	}

	void sendCollision()
	{
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y +50));
	}
}

