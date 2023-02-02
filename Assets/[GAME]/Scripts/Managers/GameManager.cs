using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private DeathLaser deathLaser;
    [SerializeField] private GameObject startGamePanel;
    public GameObject levelFailPanel;
    [SerializeField] private GameObject levelCompletePanel;
    public bool obstaclesActive;
    private void Start()
    {
        StartCoroutine(WaitBeforeStart());
    }

    private IEnumerator WaitBeforeStart()
    {
        yield return new WaitForSeconds(1.5f);
        deathLaser.axis.z = .7f;
        startGamePanel.SetActive(false);
    }
   
    
    
    public void LevelFail()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LevelComplete()
    {
       
    }
}
