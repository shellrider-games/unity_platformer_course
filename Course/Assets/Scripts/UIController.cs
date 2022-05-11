using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3;
    public Sprite heartFull,heartHalf, heartEmpty;
    public TextMeshProUGUI gemCounter;

    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelCompleteText;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        shouldFadeFromBlack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void UpdateHealthDisplay()
    {
        int currentHealth = PlayerHealthController.instance.GetCurrentHealth();
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

    public void UpdateGemCount()
    {
        gemCounter.text = LevelManager.instance.gemsCollected.ToString();
    }


}
