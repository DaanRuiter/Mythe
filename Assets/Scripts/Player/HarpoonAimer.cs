using UnityEngine;
using System.Collections;

public class HarpoonAimer : MonoBehaviour
{

    //Daan Ruiter
    //daanruiter.net

    private GameObject _target;
    private TargetLocator _targetScript;

    private bool _rotate;

    private void Start()
    {
        //create some references
        _target = GameObject.FindGameObjectWithTag("TargetLocator");
        _targetScript = _target.GetComponent<TargetLocator>();
        //initialize some variables
        _rotate = true;
    }

    private void Update()
    {
        if (_rotate)
        {
            //look at the target locator so it looks like the gun is swinging, but only do this is its allowed
            transform.rotation = Lookat2D(transform, _target.transform);
        }
    }

    public void ResetGun()
    {
        //allow the gun to continue rotating
        _rotate = true;
        _targetScript.SetPlaySound(true);
    }

    public static Quaternion Lookat2D(Transform origin, Transform target)
    {
        //works like transform.LookAt() but than in a 2D fashion.
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - origin.position, origin.TransformDirection(Vector3.up));
        return new Quaternion(0, 0, rotation.z, rotation.w);
    }

    public void SetRotate(bool b)
    {
        _rotate = b;
        _targetScript.SetPlaySound(b);
    }
}
