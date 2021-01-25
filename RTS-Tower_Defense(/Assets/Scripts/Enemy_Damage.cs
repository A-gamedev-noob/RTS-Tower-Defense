using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{

    [SerializeField]float _health = 100f;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        _health -= 25f;
        if(_health <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
