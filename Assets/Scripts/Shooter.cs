using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] Projectile projectile;

    GameObject projectilesParent;
    EnemySpawner[] EnemySpawners;
    EnemySpawner MyLaneSpawner;
    Animator animator;

    const string DEFENDER_PARENT_NAME = "Projectiles";

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawners = FindObjectsOfType<EnemySpawner>();
        animator = GetComponent<Animator>();

        CreateProjectilesParent();
        SetLaneSpawner();
    }

    private void CreateProjectilesParent()
    {
        projectilesParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!projectilesParent)
            projectilesParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsAttacking", IsAttackerInMyLane());
    }

    private void SetLaneSpawner()
    {
        foreach (var enemySpawner in EnemySpawners)
        {
            if (enemySpawner.transform.position.y == transform.position.y)
                MyLaneSpawner = enemySpawner;
        }
    }

    private bool IsAttackerInMyLane()
    {
        return MyLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation, projectilesParent.transform);
    }
}
