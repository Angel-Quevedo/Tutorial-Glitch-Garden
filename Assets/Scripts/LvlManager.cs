using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    [SerializeField] float timeToWait = 2.5f;
    int currentsceneIndex;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentsceneIndex == 0)
            StartCoroutine(WaitForTime(timeToWait));
    }

    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(currentsceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentsceneIndex + 1);
    }
    
    public void LoadStartScreen()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
