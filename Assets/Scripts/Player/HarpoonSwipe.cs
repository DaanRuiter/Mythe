using UnityEngine;
using System.Collections;

public class HarpoonSwipe : MonoBehaviour {

    public Swipezone swipezone;
    public ParticleSystem particles;
    public float minSwipeForce, maxSwipeForce;

    private HarpoonController hc;
    private SwipeMovement swipeMovement;
    private float defaultMovementSpeed;

    private void Awake()
    {
        hc = GetComponent<HarpoonController>();
        swipeMovement = new SwipeMovement();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(swipezone.IsInArea() && hc.GetDirection() == MovementDirection.Up)
        {
            swipeMovement.RegisterSwipes();
            Swipe swipe = swipeMovement.GetSwipe();
            if(swipe.direction == SwipeDirection.Up)
            {
//                hc.AddVelocity(LimitForce(swipe.swipeLength));
                particles.Emit(25);
            }
        }
    }


    private float LimitForce(float swipeForce)
    {
        if (swipeForce < 0)
        {
            swipeForce *= -1;
        }
        if (swipeForce < minSwipeForce)
        {
            swipeForce = minSwipeForce;
        }
        else if (swipeForce > maxSwipeForce)
        {
            swipeForce = maxSwipeForce;
        }
        return swipeForce;
    }
}
