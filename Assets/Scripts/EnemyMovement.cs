using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] WaveScript _waveScript;
    [SerializeField] float moveSpeed = 2f;
    
    public List<Transform> waypoints;
    private Rigidbody2D _rigidbody2D;
    private int waypointIndex = 0;
    
    void Start()
    {
        waypoints = _waveScript.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
