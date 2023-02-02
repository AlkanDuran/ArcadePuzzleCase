using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour 
{
 
    public int lastloadedsceneIndex;
    
    void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }
 
    void Start()
    {
        lastloadedsceneIndex = PlayerPrefs.GetInt("LastLoadedSceneIndex");
        if (SceneManager.GetActiveScene().buildIndex != lastloadedsceneIndex)
            SceneManager.LoadScene(lastloadedsceneIndex);
    }
 
    public void UpdateLastLoadedSceneIndex()
    {
        lastloadedsceneIndex++;
        if (lastloadedsceneIndex > 1) lastloadedsceneIndex = 0;//We increase index by one.
        PlayerPrefs.SetInt("LastLoadedSceneIndex",lastloadedsceneIndex);
        SceneManager.LoadScene(lastloadedsceneIndex);
    }
 
    public void RetryScene()
    {
        SceneManager.LoadScene(lastloadedsceneIndex);
    }
}