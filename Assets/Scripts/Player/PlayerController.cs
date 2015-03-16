using UnityEngine;
using System.Collections;
        
public class PlayerController : MonoBehaviour {

    public float minimumMovemmentSpeed, maximumMovementSpeed;

    private Rigidbody2D r;
    private SwipeMovement s;

    private Vector2 forceVector;

    public ParticleSystem PSLeft;
    public ParticleSystem PSRight;
    public HookShooter hs;

    public Swipezone movementZone;

    [HideInInspector]
    public bool active;

    private void Start()
    {
        r = GetComponent<Rigidbody2D>();
        s = new SwipeMovement();
        forceVector = new Vector2(0, 0);
        active = true;
    }

    private void Update()
    {
        if (movementZone.IsInArea() && active)
        {
            s.RegisterSwipes();
            Swipe swipe = s.GetSwipe();
            if (swipe.direction == SwipeDirection.Right)
            {
                PSLeft.Emit(12);
                forceVector.x = LimitForce(swipe.swipeLength);
                r.AddForce(forceVector);
            }
            if (swipe.direction == SwipeDirection.Left)
            {
                PSRight.Emit(12);
                forceVector.x = -LimitForce(swipe.swipeLength);
                r.AddForce(forceVector);
            }
        }
    }

    private float LimitForce(float swipeForce)
    {
        if(swipeForce < 0)
        {
            swipeForce *= -1;
        }
        if(swipeForce < minimumMovemmentSpeed)
        {
            swipeForce = minimumMovemmentSpeed;
        }else if(swipeForce > maximumMovementSpeed)
        {
            swipeForce = maximumMovementSpeed;
        }
        return swipeForce;
    }

    public void SetActive(bool state)
    {
        this.active = state;
        hs.SetActive(state);
    }
}