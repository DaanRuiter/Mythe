using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float minimumMovemmentSpeed, maximumMovementSpeed;

    private Rigidbody2D r;
    private SwipeMovement s;

    private Vector2 forceVector;
    private float nativeHeight;

    public ParticleSystem PSLeft;
    public ParticleSystem PSRight;
    public HookShooter hs;
    public Animator rowAnim;

    public Swipezone movementZone;
    public float blastMaxHeight;
    public float blastSpeed;

    [HideInInspector]
    public bool active;

    private void Start()
    {
        r = GetComponent<Rigidbody2D>();
        s = new SwipeMovement();
        forceVector = new Vector2(0, 0);
        active = true;
        nativeHeight = transform.position.y;
    }

    private void Update()
    {
        if (movementZone.IsInArea() && active && transform.position.y == nativeHeight)
        {
            s.RegisterSwipes();
            Swipe swipe = s.GetSwipe();
            if (swipe.direction == SwipeDirection.Right)
            {
                PSLeft.Emit(12);
                forceVector.x = LimitForce(swipe.swipeLength);
                r.AddForce(forceVector);
                rowAnim.SetBool("Row", true);
            }
            if (swipe.direction == SwipeDirection.Left)
            {
                PSRight.Emit(12);
                forceVector.x = -LimitForce(swipe.swipeLength);
                r.AddForce(forceVector);
                rowAnim.SetBool("Row", true);
            }
        }
        active = true;
    }

    private float LimitForce(float swipeForce)
    {
        if (swipeForce < 0)
        {
            swipeForce *= -1;
        }
        if (swipeForce < minimumMovemmentSpeed)
        {
            swipeForce = minimumMovemmentSpeed;
        }
        else if (swipeForce > maximumMovementSpeed)
        {
            swipeForce = maximumMovementSpeed;
        }
        return swipeForce;
    }

    private Vector2 pushVelocity = new Vector2(0, 0);
    public void PushUp()
    {
        if (transform.position.y < nativeHeight + blastMaxHeight)
        {
            pushVelocity.y = blastSpeed;
            transform.Translate(pushVelocity);
        }
    }

    public void PushDown()
    {
        if (transform.position.y > nativeHeight)
        {
            pushVelocity.y = -(blastSpeed * 2);
            transform.Translate(pushVelocity);
        }
        else if (
           transform.position.y < nativeHeight)
        {
            pushVelocity.y = nativeHeight - transform.position.y;
            transform.Translate(pushVelocity);
        }
    }

    public void SetActive(bool state)
    {
        this.active = state;
        hs.enabled = state;
    }
}