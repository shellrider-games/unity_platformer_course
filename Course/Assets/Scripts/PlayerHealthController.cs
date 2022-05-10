using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    
    public int maxHealth;
    public float invulLength;

    private float invulCounter;
    private int currentHealth;
    private bool invulFlicker;
    public float invulFlickerTime;
    private float invulFlickerCounter;

    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        ResetHealthToMaxHealth();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        invulFlicker = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (invulCounter > 0)
        {
            invulCounter = Mathf.Max(0.0f, invulCounter - Time.deltaTime);
            invulFlickerCounter = Mathf.Max(0.0f, invulFlickerCounter - Time.deltaTime);
            if (invulCounter == 0.0f)
            {
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g,
                    _spriteRenderer.color.b, 1.0f);
            }
            else
            {
                if (invulFlickerCounter == 0.0f)
                {
                    if (invulFlicker)
                    {
                        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g,
                            _spriteRenderer.color.b, .6f);
                    }
                    else
                    {
                        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g,
                            _spriteRenderer.color.b, 1.0f);
                    }

                    invulFlickerCounter = invulFlickerTime;
                    invulFlicker = !invulFlicker;
                }
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage()
    {
        if (!(invulCounter <= 0)) return;
        currentHealth--;
        invulCounter = invulLength;
        invulFlickerCounter = invulFlickerTime;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g,
            _spriteRenderer.color.b, 0.6f);
        invulFlicker = false;
        if (currentHealth <= 0)
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g,
                _spriteRenderer.color.b, 1.0f);
            LevelManager.instance.RespawnPlayer();
        }
        UIController.instance.UpdateHealthDisplay();
        PlayerController.instance.KnockBack();
    }

    public void HealPlayer()
    {
        currentHealth = Math.Min(currentHealth + 2, maxHealth);
        UIController.instance.UpdateHealthDisplay();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void ResetHealthToMaxHealth()
    {
        currentHealth = maxHealth;
        invulCounter = 0.0f;
        invulFlickerCounter = 0.0f;
        invulFlicker = false;
        UIController.instance.UpdateHealthDisplay();
    }
}
