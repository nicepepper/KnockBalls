using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private GameObject _firePoint;
    [SerializeField, Range(10f, 20f)] private float _reticleRange = 20.0f;
    [SerializeField] private float _power = 10.0f;
    
    private Camera _mainCamera;
    private Plane Reticle => new Plane(Vector3.back, transform.position + new Vector3(0.0f, 0.0f, _reticleRange));
    private Vector3 _speed = Vector3.zero;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        float hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Reticle.Raycast(ray, out hit);
        Vector3 shotDirection = ray.GetPoint(hit) - transform.position;
        _speed = shotDirection * _power;
        transform.rotation = Quaternion.LookRotation(shotDirection);
        
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody cannonBall = Instantiate(_cannonBallPrefab, _firePoint.transform.position,  Quaternion.identity).GetComponent<Rigidbody>();
            cannonBall.AddForce(_speed, ForceMode.VelocityChange);
        }
    }
}
