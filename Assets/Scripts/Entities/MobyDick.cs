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

	private Vector2 _scaleVector;

	private float _y;


	public bool despawning;

	void Start () 
	{
		_scale = transform.localScale.x;

		_scaleVector = new Vector2(transform.localScale.x, transform.localScale.y);

		_bezierTime = 0;

		_timer = Random.Range(4, 8);

		Invoke ("Despawn", Random.Range(14, 18));

		_negativeMovement = false;

		despawning = false;

		_y = transform.position.y;
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
		float StartPointY = -25;
		float ControlPointX = 10;
		float ControlPointY = 10;
		float EndPointX = 35;
		float EndPointY = -25;
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
			_scaleVector.x = -_scale;
			_bezierTime -= Time.deltaTime / 2;
		}else if(_negativeMovement == false)
		{
			_scaleVector.x = _scale;
			_bezierTime += Time.deltaTime / 2;
		}
		
		CurveX = (((1-_bezierTime)*(1-_bezierTime)) * StartPointX) + (2 * _bezierTime * (1 - _bezierTime) * ControlPointX) + ((_bezierTime * _bezierTime) * EndPointX);
		CurveY = (((1-_bezierTime)*(1-_bezierTime)) * StartPointY) + (2 * _bezierTime * (1 - _bezierTime) * ControlPointY) + ((_bezierTime * _bezierTime) * EndPointY);
		transform.position = new Vector2(CurveX, CurveY);

		transform.localScale = _scaleVector;

	}

	void WaterBlast()
	{
		_timer = Random.Range(4, 8);

		animations.Play("TestMobyBlast");
	}

	public void Despawn()
	{
		despawning = true;
		
		_y -= 0.2f;

		if(_y <= -35)
		{
			Destroy(this.gameObject);
		}
	}
}

