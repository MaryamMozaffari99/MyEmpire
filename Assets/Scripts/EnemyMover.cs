using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] [Range (0f , 5f)] float Speed = 1f;

    Enemy enemy;


    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        Debug.Log("waypoints" + waypoints.Length); 
        for (int i = 01; i < waypoints.Length; i++)
        {
            if (waypoints[i] != null)
            {
                path.Add(waypoints[i].GetComponent<Waypoint>());

            }
        }

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }


    IEnumerator FollowPath()
    {
        for(int i=0;i<path.Count;i++)
        {
            
            Vector3 startPosition = transform.position;
            Vector3 endPosition = path[i].transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * Speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        FinishPath();
    }

}
