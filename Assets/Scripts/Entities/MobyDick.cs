using UnityEngine;
using System.Collections;

public class MobyDick : MonoBehaviour 
{
	private float _blastTime;

	[SerializeField]
	private Animator animations;
	private float _timer;
	private float _bezierTime;
	private float _scale;
	private bool _negativeMovement;

	public bool despawning;

	void Start () 
	{
		_scale = transform.localScale.x;

		_bezierTime = 0;

		_timer = Random.Range(4, 8);

		Invoke ("Despawn", Random.Range(14, 18));

		_negativeMovement = false;

		despawning = false;
	}
	
	void FixedUpdate () 
	{
		_timer -= Time.deltaTime;

		//SteeringBehaviour();

		if(_timer <= 0)
		{
			WaterBlast();
		}

		if(despawning == false)
		{
			SteeringBehaviour();
		}else if(despawning == true)
		{
			Despawn();
		}
	}

	void SteeringBehaviour()
	{
		float StartPointX = -40;
		float StartPointY = -10;
		float ControlPointX = 10;
		float ControlPointY = 30;
		float EndPointX = 35;
		float EndPointY = -10;
		float CurveX;
		float CurveY;

		if (_bezierTime >= 1)
		{
			_negativeMovement = true;
		}else if(_bezierTime <= 0)
		{
			_negativeMovement = false;
		}

		if(_negativeMovement == true)
		{
			_scale = -6;
			_bezierTime -= Time.deltaTime / 2;
		}else if(_negativeMovement == false)
		{
			_bezierTime += Time.deltaTime / 2;
		}
		
		CurveX = (((1-_bezierTime)*(1-_bezierTime)) * StartPointX) + (2 * _bezierTime * (1 - _bezierTime) * ControlPointX) + ((_bezierTime * _bezierTime) * EndPointX);
		CurveY = (((1-_bezierTime)*(1-_bezierTime)) * StartPointY) + (2 * _bezierTime * (1 - _bezierTime) * ControlPointY) + ((_bezierTime * _bezierTime) * EndPointY);
		transform.position = new Vector2(CurveX, CurveY);

		Debug.Log(_bezierTime);
	}

	void WaterBlast()
	{
		_timer = Random.Range(4, 8);

		animations.Play("TestMobyBlast");
	}

	public void Despawn()
	{
		despawning = true;

		float _y = transform.position.y;

		_y -= 0.2f;

		if(_y <= -35)
		{
			Destroy(this.gameObject);
		}
	}
}

