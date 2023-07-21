using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private float _power = 10;
    [SerializeField] private GameObject _gunpoint;

    private Camera _mainCamera;
    private Plane _reticle => new Plane(Vector3.back, transform.position + new Vector3(0.0f, 0.0f, 10.0f));

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        float enter;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _reticle.Raycast(ray, out enter);
        Vector3 shotDirection = ray.GetPoint(enter) - transform.position;
        Vector3 speed = shotDirection * _power;
        transform.rotation = Quaternion.LookRotation(shotDirection);

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody cannonBall = Instantiate(_cannonBallPrefab, _gunpoint.transform.position,  Quaternion.identity).GetComponent<Rigidbody>();
            cannonBall.AddForce(speed, ForceMode.VelocityChange);
        }
    }
}
