using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWaypoint : MonoBehaviour
{
    private List<Transform> waypoints = new List<Transform>();
    void Start()
    {
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }
    }
}
