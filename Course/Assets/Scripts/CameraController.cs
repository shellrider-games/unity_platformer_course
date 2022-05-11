using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    
    public Transform target;
    public float minHeight, maxHeight;
    public float minX, maxX;
    public bool stopFollow;


    public Transform farBackground, middleBackground;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopFollow) return;
        Vector3 lastPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(target.position.x,minX,maxX), Mathf.Clamp(target.position.y,minHeight,maxHeight), transform.position.z);
        
        farBackground.position = new Vector3(farBackground.position.x + (transform.position.x - lastPosition.x), farBackground.position.y + (transform.position.y - lastPosition.y) * 0.9f, farBackground.position.z);
        middleBackground.position = new Vector3(middleBackground.position.x + (transform.position.x - lastPosition.x) * 0.6f, middleBackground.position.y + (transform.position.y - lastPosition.y) * 0.7f, middleBackground.position.z);
    }


}
