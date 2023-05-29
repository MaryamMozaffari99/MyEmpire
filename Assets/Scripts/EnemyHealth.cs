using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int currentHitPoints = 0;
   
    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--; 
        if (currentHitPoints <= 0)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
