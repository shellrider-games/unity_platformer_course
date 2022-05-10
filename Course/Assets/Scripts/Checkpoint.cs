using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer _SpriteRenderer;

    public Sprite cpOn, cpOff;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateAllCheckpoints();
            CheckpointController.instance.spawnPoint = transform.position;
            _SpriteRenderer.sprite = cpOn;
        }
    }

    public void ResetCheckPoint()
    {
        _SpriteRenderer.sprite = cpOff;
    }
}
