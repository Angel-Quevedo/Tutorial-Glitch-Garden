using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] float lvlTime = 10;

    bool triggered = false;

    EnemySpawner[] enemySpawners;
    GameController gameController;
    
    private void Start()
    {
        enemySpawners = FindObjectsOfType<EnemySpawner>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (triggered)
            return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / lvlTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= lvlTime);
        if (timerFinished)
        {
            Debug.Log("Lvl timer Expired!!");

            gameController.TimeFinish();
            foreach (var enemySpawner in enemySpawners)
            {
                enemySpawner.disableSpawn();
            }

        }
    }
}
