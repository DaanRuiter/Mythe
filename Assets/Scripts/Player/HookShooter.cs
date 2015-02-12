﻿using UnityEngine;
using System.Collections;

public class HookShooter : MonoBehaviour {

    //Daan Ruiter
    //daanruiter.net

    public float movementSpeed;

    private GameObject _harpoon;
    private GameObject _harpoonGun;
    private GameObject _targetLocator;

    private HarpoonController _harpoonController;
    private HarpoonAimer _harpoonAimer;
    private TargetLocator _targetLocatorScript;

    private LineRenderer _lineRenderer;

    private bool _harpoonTraveling;

    //this class mostly acts as a refernce hub and will tell all the other components to act when the player shoots the harpoon
    private void Start()
    {
        _harpoon = GameObject.FindGameObjectWithTag("Harpoon");
        _harpoonGun = GameObject.FindGameObjectWithTag("HarpoonGun");
        _targetLocator = GameObject.FindGameObjectWithTag("TargetLocator");

        _harpoonController = _harpoon.GetComponent<HarpoonController>();
        _harpoonAimer = transform.parent.GetComponent<HarpoonAimer>();
        _targetLocatorScript = _targetLocator.GetComponent<TargetLocator>();

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, transform.position);
    }

    private void Update()
    {
        _lineRenderer.SetPosition(1, _harpoon.transform.position);
    }

    public void ShootHarpoon()
    {
        _harpoon.transform.parent = null;
        _harpoon.transform.rotation = HarpoonAimer.Lookat2D(_harpoon.transform, _targetLocator.transform);
        _harpoonController.ShootAt(_targetLocator.transform.position);
        _harpoonAimer.rotate = false;
    }
}
