using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MovementDirection
{
    None,
    Down,
    Up
}

public class HarpoonController : MonoBehaviour
{

    //Daan Ruiter
    //daanruiter.net

    public float movementSpeed;
    public float distanceForReset;
    public SpriteRenderer aimingArrow;

    private float _baseMovementSpeed;

    private Vector2 _target; 
    private Vector2 _startPosition;

    private MovementDirection _movementDirection;
    private GameObject _harpoonObject;

    private HarpoonAimer _harpoonAimer;
    private SpriteRenderer _sprite;

    private List<GameObject> _fishesOnHarpoon;

    private void Start()
    {
        //create some references
        _harpoonObject = GameObject.FindGameObjectWithTag("HarpoonObject");
        _harpoonAimer = _harpoonObject.GetComponent<HarpoonAimer>();
        _sprite = GetComponent<SpriteRenderer>();

        //initialize some variables.
        _movementDirection = MovementDirection.None;
        _fishesOnHarpoon = new List<GameObject>();
        _startPosition = transform.localPosition;
        _target = Vector2.zero;
        _baseMovementSpeed = movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //at this point the harpoon has collided with an object
        //now it will reel the object back into the ship
        if(col.GetComponent<Interactables>())
        {
            if (_movementDirection == MovementDirection.Down)
            {
                SwitchDirection();
                col.GetComponent<Interactables>().PickUp(transform);
                _fishesOnHarpoon.Add(col.gameObject);
            }
        }
    }

    private void Update()
    {
        if (_target != Vector2.zero)
        {
            //move towards the target
            if(_movementDirection == MovementDirection.Down)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, _target, movementSpeed * Time.deltaTime);
            }
                //move in a backgwards motion so it looks like the harpoon is being pulled back up
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, _harpoonObject.transform.position, movementSpeed * Time.deltaTime);
                //Here we update the _target position because the player might mave moved the ship while the harpoon has being rectracted
                _target = _harpoonObject.transform.position;
            }
            //check if the harpoon has reached the gun
            if(_movementDirection == MovementDirection.Up && Vector3.Distance(transform.localPosition, _target) < distanceForReset)
            {
                ReAtachToGun();
            }
        }
    }

    public void ShootAt(Vector2 target)
    {
         //Set the target, the direction and save the position it was in before the gun was shot
         _target = target;
         _movementDirection = MovementDirection.Down;
         _sprite.enabled = true;
         aimingArrow.enabled = false;
    }

    private void ReAtachToGun()
    {
        //nullify the target & direction
        _target = Vector2.zero;
        _movementDirection = MovementDirection.None;
        //put the harpoon back in the right position
        transform.parent = _harpoonObject.transform;
        transform.localPosition = _startPosition;
        //tell the gun && targetlocator to start rotating again
        _harpoonAimer.ResetGun();
        //collect all the interactables the harpoon has collected
        for (int i = 0; i < _fishesOnHarpoon.Count; i++)
        {
            Game.instance.HandleInteractable(_fishesOnHarpoon[i].GetComponent<Interactables>());
            Destroy(_fishesOnHarpoon[i]);
        }
        _fishesOnHarpoon.Clear();
        _sprite.enabled = false;
        aimingArrow.enabled = true;
    }

    public void SwitchDirection()
    {
        if (_movementDirection == MovementDirection.Down)
        {
            //change the direction & reverse the starting target en the aimer target
            _movementDirection = MovementDirection.Up;
        }
        else
        {
            //change the direction
            _movementDirection = MovementDirection.Down;
        }
    }

    public MovementDirection GetDirection()
    {
        return this._movementDirection;
    }
}
