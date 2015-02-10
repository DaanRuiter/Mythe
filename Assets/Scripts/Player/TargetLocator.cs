using UnityEngine;
using System.Collections;

public class TargetLocator : MonoBehaviour {

	public Transform transformA;
    public Transform transformB;  
    public Vector3 bending = Vector3.up;                
    public float timeToTravel = 10.0f;
    public float directionSwithDistance;

    private Vector3 _currentDestination;

     private void Start () {
         StartCoroutine(MoveToPosition(transformA.position, transformB.position));
         _currentDestination = transformB.position;
     }
 
    private void Update()
     {
         if (Vector3.Distance(transform.position, _currentDestination) < directionSwithDistance)
         {
             SwitchDirection();
         }
     }

    private IEnumerator MoveToPosition (Vector3 originPosition, Vector3 destination) {
         float timeStamp = Time.time;
         while (Time.time<timeStamp+timeToTravel) {

             Vector3 currentPos = Vector3.zero;

             currentPos = Vector3.Lerp(originPosition, destination, (Time.time - timeStamp) / timeToTravel);
         
             currentPos.x += bending.x*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
             currentPos.y += bending.y*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
             currentPos.z += bending.z*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);

             transform.position = currentPos;

             yield return null;
         }
    }

    private void SwitchDirection()
    {
        if(_currentDestination == transformA.position)
        {
            _currentDestination = transformB.position;
            StopAllCoroutines();
            StartCoroutine(MoveToPosition(transformA.position, transformB.position));
        }
        else
        {
            _currentDestination = transformA.position;
            StopAllCoroutines();
            StartCoroutine(MoveToPosition(transformB.position, transformA.position));
        }
    }
}
