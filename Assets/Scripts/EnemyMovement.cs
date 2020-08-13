using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    WaveScript _waveScript;
    float moveSpeed;
    List<Transform> waypoints;
    private int waypointIndex = 0;

    public void SetWaveConfig(WaveScript waveScript)
    {
        _waveScript = waveScript;
        moveSpeed = waveScript.GetEnemiesSpeed();
        waypoints = waveScript.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            Transform targetPosition = waypoints[waypointIndex];
            transform.position = Vector2.MoveTowards(
            transform.position, 
            targetPosition.position, 
            moveSpeed * Time.deltaTime
            );
            if (targetPosition.position == transform.position)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
