using UnityEngine;
using System.Collections;

public class HarpoonAimer : MonoBehaviour {

    private GameObject _target;

    public bool rotate;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("TargetLocator");
        rotate = true;
    }

    private void Update()
    {
        if (rotate)
        {
            transform.rotation = Lookat2D(transform, _target.transform);
        }
    }

    public void ResetGun()
    {
        rotate = true;
    }

    public static Quaternion Lookat2D(Transform origin, Transform target)
    {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - origin.position, origin.TransformDirection(Vector3.up));
        return new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
