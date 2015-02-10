using UnityEngine;
using System.Collections;

public enum MovementDirection
{
    None,
    Down,
    Up
}

public class HarpoonController : MonoBehaviour {

    public float movementSpeed;
    public float distanceForReset;

    private Vector3 _target;
    private Vector3 _startPosition;

    private MovementDirection _movementDirection;
    private GameObject _harpoonGun;
    private HarpoonAimer _harpoonAimer;

    private void Start()
    {
        _harpoonGun = GameObject.FindGameObjectWithTag("HarpoonGun");
        _movementDirection = MovementDirection.None;
        _target = Vector3.zero;
        _harpoonAimer = GameObject.FindGameObjectWithTag("HarpoonObject").GetComponent<HarpoonAimer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        SwitchDirection();
    }

    private void Update()
    {
        if (_target != Vector3.zero)
        {
            if(_movementDirection == MovementDirection.Down)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _harpoonGun.transform.position, movementSpeed * Time.deltaTime);
            }
            if(_movementDirection == MovementDirection.Up && Vector3.Distance(transform.position, _target) < distanceForReset)
            {
                ReAtachToGun();
            }
        }
    }

    public void ShootAt(Vector3 target)
    {
        _target = target;
        _movementDirection = MovementDirection.Down;

        _startPosition = transform.position;
    }

    private void ReAtachToGun()
    {
        _target = Vector3.zero;
        _movementDirection = MovementDirection.None;
        _harpoonAimer.ResetGun();
        transform.parent = _harpoonGun.transform;
        transform.position = _startPosition;
    }

    private void SwitchDirection()
    {
        if (_movementDirection == MovementDirection.Down)
        {
            _movementDirection = MovementDirection.Up;
            _target = _harpoonGun.transform.position;
        }
        else
        {
            _movementDirection = MovementDirection.Down;
        }
    }
}
