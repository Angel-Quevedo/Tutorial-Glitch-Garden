using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(.1f, 5f)] [SerializeField] float movementSpeed = 1f;

    GameObject currentTarget;

    bool readyToMove = true;


    private void Awake()
    {
        FindObjectOfType<GameController>().AddEnemy();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToMove)
            Move();

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
            GetComponent<Animator>().SetBool("IsAttacking", false);
    }

    private void Move()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    public void EnableMovement()
    {
        readyToMove = true;
    }

    public void DisableMovement()
    {
        readyToMove = false;
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public void Atack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget)
            return;

        Health health = currentTarget.GetComponent<Health>();

        if (health)
            health.DealDamage(damage);
    }

    private void OnDestroy()
    {
        FindObjectOfType<GameController>()?.DecreaseEnemy();
    }
}
