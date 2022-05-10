using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    private Checkpoint[] checkpoints;
    public Vector3 spawnPoint;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = FindObjectOfType<PlayerController>().GetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateAllCheckpoints()
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.ResetCheckPoint();
        }
    }
}
