using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGem;
    public bool isHeal;
    private bool isCollected;

    public GameObject pickupEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                UIController.instance.UpdateGemCount();
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                AudioManager.instance.playSFX(6);
            }

            if (isHeal)
            {
                if (PlayerHealthController.instance.GetCurrentHealth() != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    AudioManager.instance.playSFX(7);
                }
            }
        }
    }
}
