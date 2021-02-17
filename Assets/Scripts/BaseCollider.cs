using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    [SerializeField] HealthDisplay healthDisplay;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionGameObject = collision.gameObject;

        if (collisionGameObject.GetComponent<Enemy>())
        {
            healthDisplay.ReduceHealth(1);
            Destroy(collisionGameObject);
        }
    }
}
