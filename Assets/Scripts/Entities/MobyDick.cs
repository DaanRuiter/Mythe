using UnityEngine;
using System.Collections;

public class MobyDick : MonoBehaviour
{
<<<<<<< HEAD
	[SerializeField]
	private Animator animations;

	[SerializeField]
	private float _despawnTimeMin;
	
	[SerializeField]
	private float _despawnTimeMax;

	private float _blastTime;
	private float _timer;
	private float _bezierTime;
	private float _scale;
	private float _y;
	private float _checkPlaying;

	private bool _negativeMovement;

	private Vector2 _scaleVector;
	private Vector2 _direction;

	public bool despawning;

	void Start () 
	{
		_checkPlaying = 0;

		_scale = transform.localScale.x;

		_scaleVector = new Vector2(transform.localScale.x, transform.localScale.y);

		_bezierTime = 0;

		_timer = Random.Range(4, 8);

		Invoke ("Despawn", Random.Range(_despawnTimeMin, _despawnTimeMax));

		_negativeMovement = false;

		despawning = false;

		_y = transform.position.y;
	}
	
	void FixedUpdate () 
	{
		_timer -= Time.deltaTime;

		_checkPlaying -= Time.deltaTime;

		if(_timer <= 0)
		{
			WaterBlast();
		}

		if(_checkPlaying <= 0 && despawning == false)
		{
			SteeringBehaviour();
		}else if(despawning == true)
		{
			Despawn();
		}
	}

	void SteeringBehaviour()
	{
		float startPointX = -40;
		float startPointY = -25;
		float controlPointX = 10;
		float controlPointY = 10;
		float endPointX = 35;
		float endPointY = -25;
		float curveX;
		float curveY;

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
		
		curveX = (((1-_bezierTime)*(1-_bezierTime)) * startPointX) + (2 * _bezierTime * (1 - _bezierTime) * controlPointX) + ((_bezierTime * _bezierTime) * endPointX);
		curveY = (((1-_bezierTime)*(1-_bezierTime)) * startPointY) + (2 * _bezierTime * (1 - _bezierTime) * controlPointY) + ((_bezierTime * _bezierTime) * endPointY);

		_direction = new Vector2(curveX, curveY);

		transform.position = _direction;

		transform.localScale = _scaleVector;

	}

	void WaterBlast()
	{
		_timer = Random.Range(4, 8);
		_checkPlaying = 0.9f;
		animations.Play("TestMobyBlast");
	}

	public void Despawn()
	{
		despawning = true;

		_direction = new Vector2(transform.position.x, _y);

		_y -= 0.2f;

		if(_y <= -35)
		{
			Destroy(this.gameObject);
		}

		transform.position = _direction;
	}
}
=======
    private float _blastTime;
>>>>>>> origin/master

    [SerializeField]
    private Animator animations;
    private float _timer;
    private float _bezierTime;
    private float _scale;
    private bool _negativeMovement;

    private Vector2 _scaleVector;

    private float _y;


    public bool despawning;

    void Start()
    {
        _scale = transform.localScale.x;

        _scaleVector = new Vector2(transform.localScale.x, transform.localScale.y);

        _bezierTime = 0;

        _timer = Random.Range(4, 8);

        Invoke("Despawn", Random.Range(14, 18));

        _negativeMovement = false;

        despawning = false;

        _y = transform.position.y;
    }

    void FixedUpdate()
    {
        _timer -= Time.deltaTime;

        //SteeringBehaviour();

        if (_timer <= 0)
        {
            WaterBlast();
        }

        if (despawning == false)
        {
            SteeringBehaviour();
        }
        else if (despawning == true)
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
        }
        else if (_bezierTime <= 0)
        {
            _negativeMovement = false;
        }

        if (_negativeMovement == true)
        {
            _scaleVector.x = -_scale;
            _bezierTime -= Time.deltaTime / 2;
        }
        else if (_negativeMovement == false)
        {
            _scaleVector.x = _scale;
            _bezierTime += Time.deltaTime / 2;
        }

        CurveX = (((1 - _bezierTime) * (1 - _bezierTime)) * StartPointX) + (2 * _bezierTime * (1 - _bezierTime) * ControlPointX) + ((_bezierTime * _bezierTime) * EndPointX);
        CurveY = (((1 - _bezierTime) * (1 - _bezierTime)) * StartPointY) + (2 * _bezierTime * (1 - _bezierTime) * ControlPointY) + ((_bezierTime * _bezierTime) * EndPointY);
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

        if (_y <= -35)
        {
            Destroy(this.gameObject);
        }
    }
}
