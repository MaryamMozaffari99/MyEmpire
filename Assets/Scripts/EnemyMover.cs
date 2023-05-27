using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range (0f , 5f)] float Speed = 1f;

    void Start()
    {
        //PrintWaypointName();
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            //transform.position = waypoint.transform.position;

            transform.LookAt(endPosition);

           // yield return new WaitForSeconds(waitTime);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * Speed ;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
    }
    //void PrintWaypointName()
    //{
    //    foreach (Waypoint waypoint in path)
    //    {
    //        Debug.Log(waypoint.name); 
    //    }
    //}
    
}
