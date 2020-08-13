using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private float padding = 0.25f;
    [SerializeField] private GameObject laserBullet1;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] private float weaponReloadTime = 0.3f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    private bool isReadyToShoot = true;
    void Start()
    {
        SetUpBoundaries();
    }
    
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1") && isReadyToShoot)
        {
            StartCoroutine("WeaponReloadHandler");
            var bullet = Instantiate(laserBullet1, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, bulletSpeed);
        }
    }

    IEnumerator WeaponReloadHandler()
    {
        isReadyToShoot = false;
        yield return new WaitForSeconds(weaponReloadTime);
        isReadyToShoot = true;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal"); 
        var newXPos = Mathf.Clamp(transform.position.x + (deltaX * moveSpeed * Time.deltaTime), xMin, xMax);
        
        var deltaY = Input.GetAxis("Vertical"); 
        var newYPos = Mathf.Clamp(transform.position.y + (deltaY * moveSpeed * Time.deltaTime), yMin, yMax);

        transform.position = new Vector2(newXPos , newYPos);
    }
    
    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

}
