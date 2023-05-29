using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int currentHitPoints = 0;

    Enemy enemy;
   
    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
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
            enemy.RewardGold();

            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
