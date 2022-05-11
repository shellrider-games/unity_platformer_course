using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string levelToLoad;
    public float waitToRespawn;
    public float killYPos;

    public int gemsCollected;
    
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

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.playSFX(8);
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.shouldFadeToBlack = true;
        yield return new WaitForSeconds(1.0f/UIController.instance.fadeSpeed);
        UIController.instance.shouldFadeFromBlack = true;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerController.instance.rigidBody.velocity = new Vector2(0.0f, 0.0f);
        PlayerController.instance.ResetKnockBack();
        PlayerHealthController.instance.ResetHealthToMaxHealth();
    }
    
    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    private IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.shouldFadeToBlack = true;
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed));
        SceneManager.LoadScene(levelToLoad);
    }
}
