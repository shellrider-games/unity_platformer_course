using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deathEffect;
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
        if (other.CompareTag("Enemy"))
        {
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            other.transform.parent.gameObject.SetActive(false);
            
            
            PlayerController.instance.Bounce();
            AudioManager.instance.playSFX(3);
        }
    }
}
