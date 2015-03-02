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

    private Vector3 _target;
    private Vector3 _startPosition;

    private MovementDirection _movementDirection;
    private GameObject _harpoonObject;

    private HarpoonAimer _harpoonAimer;
    private TargetLocator _targetLocator;

    private List<GameObject> _fishesOnHarpoon;

    private void Start()
    {
        //create some references
        _harpoonObject = GameObject.FindGameObjectWithTag("HarpoonObject");
        _harpoonAimer = _harpoonObject.GetComponent<HarpoonAimer>();
        _targetLocator = GameObject.FindGameObjectWithTag("TargetLocator").GetComponent<TargetLocator>();

        //initialize some variables.
        _movementDirection = MovementDirection.None;
        _target = Vector3.zero;
        _fishesOnHarpoon = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //at this point the harpoon has collided with an object
        //now it will reel the object back into the ship
        if(col.GetComponent<Interactables>())
        {
            if (_movementDirection != MovementDirection.Up)
            {
                SwitchDirection();
                col.GetComponent<Interactables>().PickUp(transform);
                _fishesOnHarpoon.Add(col.gameObject);
            }
        }
    }

    private void Update()
    {
        if (_target != Vector3.zero)
        {
            //move towards the target
            if(_movementDirection == MovementDirection.Down)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, movementSpeed * Time.deltaTime);
            }
                //move in a backgwards motion so it looks like the harpoon is being pulled back up
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _harpoonObject.transform.position, movementSpeed * Time.deltaTime);
            }
            //check if the harpoon has reached the gun
            if(_movementDirection == MovementDirection.Up && Vector3.Distance(transform.position, _target) < distanceForReset)
            {
                ReAtachToGun();
            }
        }
    }

    public void ShootAt(Vector3 target)
    {
         //Set the target, the direction and save the position it was in before the gun was shot
         _target = target;
         _movementDirection = MovementDirection.Down;
         _startPosition = transform.position;
    }

    private void ReAtachToGun()
    {
        //nullify the target & direction
        _target = Vector3.zero;
        _movementDirection = MovementDirection.None;
        //put the harpoon back in the right position
        transform.parent = _harpoonObject.transform;
        transform.position = _startPosition;
        //tell the gun && targetlocator to start rotating again
        _harpoonAimer.ResetGun();
        for (int i = 0; i < _fishesOnHarpoon.Count; i++)
        {
			Destroy(_fishesOnHarpoon[i]);
            Game.instance.AddScore(_fishesOnHarpoon[i].GetComponent<Interactables>().GetPoints());
            Game.instance.HandleInteractable(_fishesOnHarpoon[i].GetComponent<Interactables>());
            Game.instance.AddScore(_fishesOnHarpoon[i].GetComponent<Interactables>().GetPoints());
<<<<<<< HEAD
//            Game.instance.AddScore(_fishesOnHarpoon[i].GetComponent<FishPickup>().GetPointWorth());
=======
>>>>>>> origin/master
            Destroy(_fishesOnHarpoon[i]);
        }
        _fishesOnHarpoon.Clear();
    }

    public void SwitchDirection()
    {
        if (_movementDirection == MovementDirection.Down)
        {
            //change the direction & reverse the starting target en the aimer target
            _movementDirection = MovementDirection.Up;
            _target = _harpoonObject.transform.position;
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
