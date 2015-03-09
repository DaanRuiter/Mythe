using UnityEngine;
using System.Collections;

public class TargetLocator : MonoBehaviour
{

    //Daan Ruiter
    //daanruiter.net

    public GameObject transformA;
    public GameObject transformB;
    public float bending = 0f;
    public float timeToTravel = 10.0f;
    public float directionSwithDistance;

    private GameObject _currentDestination;

    private void Start()
    {
        //start moving the target between the 2 points in a curve.
        StartCoroutine(MoveToPosition(transformA.transform.localPosition, transformB.transform.localPosition));
        //tell what target the gun should start with moving towards
        _currentDestination = transformB;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.transform.localPosition, _currentDestination.transform.localPosition) < directionSwithDistance)
        {
            //if the targetlocator has reached its destination, set the destination to the other target
            SwitchDirection();
        }
    }

    private IEnumerator MoveToPosition(Vector3 originPosition, Vector3 destination)
    {
        //save the current time
        float timeStamp = Time.time;
        while (Time.time < timeStamp + timeToTravel)
        {
            //reset the vector
            Vector3 currentPos = Vector3.zero;
            //create a lerping motion
            currentPos = Vector3.Lerp(originPosition, destination, (Time.time - timeStamp) / timeToTravel);
            //apply the curve
            currentPos.y += bending * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            //draw a line so we can see the path if followed, i'm using a region so this will not be compiled in the final build.
#if UNITY_EDITOR
            Debug.DrawLine(transform.localPosition, currentPos, Color.green, 5f);
#endif
            //move it accordingly
            transform.localPosition = currentPos;

            yield return null;
        }
    }

    private void SwitchDirection()
    {
        if (_currentDestination == transformA)
        {
            //change the current destination
            _currentDestination = transformB;
            //stop the courentine
            StopAllCoroutines();
            //start a new one with out new target
            StartCoroutine(MoveToPosition(transformA.transform.localPosition, transformB.transform.localPosition));
        }
        else
        {
            //same as above in reverse
            _currentDestination = transformA;
            StopAllCoroutines();
            StartCoroutine(MoveToPosition(transformB.transform.localPosition, transformA.transform.localPosition));
        }
    }
}
