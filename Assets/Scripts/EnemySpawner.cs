using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] bool enableSpawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Enemy[] enemies;

    GameController gameController;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        gameController = FindObjectOfType<GameController>();

        while (enableSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }    
    }

    private void SpawnEnemy()
    {
        var randomIndex = Random.Range(0, enemies.Length);
        Spawn(enemies[randomIndex]);
    }

    private void Spawn(Enemy enemy)
    {
        var newEnemy = Instantiate(enemy, transform.position, transform.rotation, transform);
    }

    public void disableSpawn()
    {
        enableSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
