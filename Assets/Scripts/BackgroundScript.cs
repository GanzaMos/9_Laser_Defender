using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private Material _material;
    [SerializeField] private float backgroundSpeed = 0.5f;
    private Vector2 offset;
    
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundSpeed);
    }
    
    void Update()
    {
        _material.mainTextureOffset += offset * Time.deltaTime;
    }
}
