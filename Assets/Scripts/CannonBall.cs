using System;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private GameObject _cannonballExplosion;
    [SerializeField] private float _lifetime = 5;
    [SerializeField, Range(1, 1000)] 
    private int _damage = 1;
    private float time = 0f;
    
    private void Update()
    {
        DeathCountdown();
    }

    private void DeathCountdown()
    {
        time += Time.deltaTime;
        if (time > _lifetime)
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        if (_cannonballExplosion != null)
        {
            _cannonballExplosion = Instantiate(
                _cannonballExplosion, 
                gameObject.transform.position, 
                Quaternion.identity);
            Destroy(_cannonballExplosion, 2);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void HitObject(GameObject theObject)
    {
        var target = theObject.GetComponentInParent<Enemy.Enemy>();
        if (target)
        {
            target.TakeDamage(_damage);
            Explosion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitObject(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        HitObject(other.gameObject);
    }
}
