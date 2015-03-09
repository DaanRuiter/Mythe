using UnityEngine;
using System.Collections;
        
public class PlayerController : MonoBehaviour {

    public float minimumMovemmentSpeed, maximumMovementSpeed;

    private Rigidbody2D r;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector2 currentSwipeNorm;

    private Vector2 forceVector;

    public ParticleSystem PSLeft;
    public ParticleSystem PSRight;

    private void Start()
    {
        r = GetComponent<Rigidbody2D>();
        forceVector = new Vector2(0, 0);
    }

    private void Update()
    {
         if(Input.GetMouseButtonDown(0))
         {
             //save touch 2d point
             firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
         }
         if(Input.GetMouseButtonUp(0))
         {
            //save touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
       
            //create a vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipeNorm = currentSwipe;

            //normalize the 2d vector
            currentSwipeNorm.Normalize();
 
            //swipe upwards
            if (currentSwipeNorm.y > 0 && currentSwipeNorm.x > -0.5f && currentSwipeNorm.x < 0.5f)
            {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipeNorm.y < 0 && currentSwipeNorm.x > -0.5f && currentSwipeNorm.x < 0.5f)
            {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipeNorm.x < 0 && currentSwipeNorm.y > -0.5f && currentSwipeNorm.y < 0.5f)
            {
                PSRight.Emit(12);
                forceVector.x = -LimitForce(currentSwipe.x);
                print(currentSwipe.x);
                r.AddForce(forceVector);
            }
            //swipe right
            if (currentSwipeNorm.x > 0 && currentSwipeNorm.y > -0.5f && currentSwipeNorm.y < 0.5f)
            {
                PSLeft.Emit(12);
                forceVector.x = LimitForce(currentSwipe.x);
                print(currentSwipe.x);
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