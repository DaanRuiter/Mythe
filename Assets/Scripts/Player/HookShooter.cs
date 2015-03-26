using UnityEngine;
using System.Collections;

public class HookShooter : MonoBehaviour {

    //Daan Ruiter
    //daanruiter.net

    public Animator playerAnim;

    private GameObject _harpoon;
    private GameObject _targetLocator;

    private HarpoonController _harpoonController;
    private HarpoonAimer _harpoonAimer;

    private LineRenderer _lineRenderer;

    private bool _harpoonTraveling;

    //this class mostly acts as a refernce hub and will tell all the other components to act when the player shoots the harpoon
    private void Start()
    {
        _harpoon = GameObject.FindGameObjectWithTag("Harpoon");
        _targetLocator = GameObject.FindGameObjectWithTag("TargetLocator");

        _harpoonController = _harpoon.GetComponent<HarpoonController>();
        _harpoonAimer = transform.parent.GetComponent<HarpoonAimer>();

        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.SetPosition(0, transform.position);
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _harpoon.transform.position);
    }

    public void ShootHarpoon()
    {
        if (_harpoonController.GetDirection() == MovementDirection.None)
        {
            _harpoon.transform.parent = null;
            _harpoon.transform.rotation = HarpoonAimer.Lookat2D(_harpoon.transform, _targetLocator.transform);
            _harpoonController.ShootAt(_targetLocator.transform.position);
            _harpoonAimer.SetRotate(false);
            playerAnim.SetTrigger("ThrowHarpoon");
        }
    }
}
