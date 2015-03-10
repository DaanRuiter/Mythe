using UnityEngine;
using System.Collections;
        
public class PlayerController : MonoBehaviour {

    public float minimumMovemmentSpeed, maximumMovementSpeed;

    private Rigidbody2D r;

    private Vector2 forceVector;

    public ParticleSystem PSLeft;
    public ParticleSystem PSRight;

    public Swipezone movementZone;

    [HideInInspector]
    public bool active;

    private void Start()
    {
        r = GetComponent<Rigidbody2D>();
        forceVector = new Vector2(0, 0);
        active = true;
    }

    private void Update()
    {
        if (movementZone.IsInArea() && active)
        {
            Swipe sipe = SwipeMovement.Get.Swipe();
            if (sipe.direction == SwipeDirection.Right)
            {
                PSLeft.Emit(12);
                forceVector.x = LimitForce(SwipeMovement.Get.Swipe().swipeLength);
                r.AddForce(forceVector);
            }
            if (sipe.direction == SwipeDirection.Left)
            {
                PSRight.Emit(12);
                forceVector.x = -LimitForce(SwipeMovement.Get.Swipe().swipeLength);
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
}