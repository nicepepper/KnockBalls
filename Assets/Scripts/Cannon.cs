using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private float _power = 10;
    [SerializeField] private GameObject _gunpoint;
    [SerializeField] private float _reticleRange = 20.0f;

    private Camera _mainCamera;
    private Plane Reticle => new Plane(Vector3.back, transform.position + new Vector3(0.0f, 0.0f, _reticleRange));
    private Vector3 _speed = Vector3.zero;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        float target;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Reticle.Raycast(ray, out target);
        Vector3 shotDirection = ray.GetPoint(target) - transform.position;
        _speed = shotDirection * _power;
        transform.rotation = Quaternion.LookRotation(shotDirection);
        
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody cannonBall = Instantiate(_cannonBallPrefab, _gunpoint.transform.position,  Quaternion.identity).GetComponent<Rigidbody>();
            cannonBall.AddForce(_speed, ForceMode.VelocityChange);
        }
    }
}
