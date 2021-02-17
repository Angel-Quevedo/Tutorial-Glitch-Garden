using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 10f;
    [SerializeField] int totalEnemies = 0;
    [SerializeField] bool timeFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }


    public void TimeFinish()
    {
        timeFinish = true;

        if (timeFinish && totalEnemies <= 0)
        {
            FinishLvl();
        }
    }

    public void AddEnemy()
    {
        totalEnemies += 1;
    }

    public void DecreaseEnemy()
    {
        totalEnemies -= 1;

        if (timeFinish && totalEnemies <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(waitToLoad);

        FindObjectOfType<LvlManager>().LoadNextScene();
    }


    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void FinishLvl()
    {
        Debug.Log("Lvl is finished");
    }
}
