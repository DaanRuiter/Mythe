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
			Debug.DrawLine(new Vector2(this.transform.position.x + 10, this.transform.position.y), new Vector2(this.transform.position.x+10, this.transform.position.y +50) , Color.green, _waterBlast.duration);
		}
	}

	void SteeringBehaviour()
	{
		movement = new Vector2(_x, _y);

		float borderX = 30f;

		//Vector3 positiveBorder = new Vector3(borderX, 0, 0);
		//Vector3 negativeBorder = new Vector3(-borderX, 0, 0);


		if(_x <= -borderX)
		{
			_negativeMovement = false;
		}else if(_x >= borderX)
		{
			_negativeMovement = true;
		}
		if(_negativeMovement)
		{
			_x -= 0.25f;
		}else if(!_negativeMovement)
		{
			_x += 0.25f;
		}



		if(this.transform.position.y <= -15)
		{
			_y += Mathf.Sin(Time.deltaTime) * Mathf.PI;
		}



		transform.position = movement;
	}

	void WaterBlast()
	{
		_waterBlast.Play();
	}

	void sendCollision()
	{
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x + 10, this.transform.position.y), new Vector2(this.transform.position.x+10, this.transform.position.y +50));
	}
}

