using UnityEngine;
using System.Collections;

public enum SwipeDirection
{
    None,
    Up,
    Right,
    Down,
    Left
}

public class Swipe
{
    public SwipeDirection direction;
    public float swipeLength;

    public Swipe(SwipeDirection dir, float length)
    {
        this.direction = dir;
        this.swipeLength = length;
    }
}

public class SwipeMovement : MonoBehaviour {

    public static SwipeMovement Get; void Awake() { Get = this; }

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector2 currentSwipeNorm;

    private Vector2 forceVector;

    private Swipe latestSwipe;

    private void Start()
    {
        latestSwipe = new Swipe(SwipeDirection.None, 0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create a vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipeNorm = currentSwipe;

            //normalize the 2d vector
            currentSwipeNorm.Normalize();

            //swipe up
            if (currentSwipeNorm.y > 0 && currentSwipeNorm.x > -0.5f && currentSwipeNorm.x < 0.5f)
            {
                latestSwipe = new Swipe(SwipeDirection.Up, currentSwipe.y);
            }
            //swipe down
            if (currentSwipeNorm.y < 0 && currentSwipeNorm.x > -0.5f && currentSwipeNorm.x < 0.5f)
            {
                latestSwipe = new Swipe(SwipeDirection.Down, currentSwipe.y);
            }
            //swipe left
            if (currentSwipeNorm.x < 0 && currentSwipeNorm.y > -0.5f && currentSwipeNorm.y < 0.5f)
            {
                latestSwipe = new Swipe(SwipeDirection.Left, currentSwipe.x);
            }
            //swipe right
            if (currentSwipeNorm.x > 0 && currentSwipeNorm.y > -0.5f && currentSwipeNorm.y < 0.5f)
            {
                latestSwipe = new Swipe(SwipeDirection.Right, currentSwipe.x);
            }
        }
    }

    public Swipe Swipe()
    {
        if(currentSwipe != null)
        {
            Swipe toReturn = latestSwipe;
            latestSwipe = new Swipe(SwipeDirection.None, 0f);
            return toReturn;
        }
        else
        {
            return new Swipe(SwipeDirection.None, 0f);
        }
    }
}
