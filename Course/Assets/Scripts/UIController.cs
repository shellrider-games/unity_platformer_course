using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3;
    public Sprite heartFull,heartHalf, heartEmpty;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        int currentHealth = PlayerHealthController.instance.getCurrentHealth();
        heart1.sprite = heartEmpty;
        heart2.sprite = heartEmpty;
        heart3.sprite = heartEmpty;
        if (currentHealth >= 1) heart1.sprite = heartHalf;
        if (currentHealth >= 2) heart1.sprite = heartFull;
        if (currentHealth >= 3) heart2.sprite = heartHalf;
        if (currentHealth >= 4) heart2.sprite = heartFull;
        if (currentHealth >= 5) heart3.sprite = heartHalf;
        if (currentHealth >= 6) heart3.sprite = heartFull;
    }
}
