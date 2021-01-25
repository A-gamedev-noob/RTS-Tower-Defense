using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    
    [SerializeField] Transform _lookAt, _pointer;
    [SerializeField] float _range = 50f;
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _bulletSpeed = 10f;

    void Start()
    {
        
    }


    void Update()
    {
        if(IsInRange())
        {
            _pointer.LookAt(_lookAt);
        }
        Shooting();
    }

    bool IsInRange()
    {
        Collider[] Enemies = Physics.OverlapSphere(transform.position,_range,_enemyLayer);
        if(Enemies.Length != 0)
        {
            return true;
        }
        else{
            return false;
        }
    }

    void Shooting()
    {
        if(IsInRange())
        {
            
        }
        else{

        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,_range);    
    }
}
