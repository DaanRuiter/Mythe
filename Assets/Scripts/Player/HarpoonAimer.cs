using UnityEngine;
using System.Collections;

public class HarpoonAimer : MonoBehaviour
{

    //Daan Ruiter
    //daanruiter.net

    private GameObject _target;

    public bool rotate;

    private void Start()
    {
        //create some references
        _target = GameObject.FindGameObjectWithTag("TargetLocator");
        //initialize some variables
        rotate = true;
    }

    private void Update()
    {
        if (rotate)
        {
            //look at the target locator so it looks like the gun is swinging, but only do this is its allowed
            transform.rotation = Lookat2D(transform, _target.transform);
        }
    }

    public void ResetGun()
    {
        //allow the gun to continue rotating
        rotate = true;
    }

    public static Quaternion Lookat2D(Transform origin, Transform target)
    {
        //works like transform.LookAt() but than in a 2D fashion.
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - origin.position, origin.TransformDirection(Vector3.up));
        return new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
