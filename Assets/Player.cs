using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private float padding = 0.25f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    void Start()
    {
        SetUpBoundaries();
    }

    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal"); 
        var newXPos = Mathf.Clamp(transform.position.x + (deltaX * moveSpeed * Time.deltaTime), xMin, xMax);
        
        var deltaY = Input.GetAxis("Vertical"); 
        var newYPos = Mathf.Clamp(transform.position.y + (deltaY * moveSpeed * Time.deltaTime), yMin, yMax);

        transform.position = new Vector2(newXPos , newYPos);
    }
}
