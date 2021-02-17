using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFK;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    private void Die()
    {
        if (deathVFK)
        {
            var deathVFXObject = Instantiate(deathVFK, transform.position, Quaternion.identity);
            Destroy(deathVFXObject, deathVFXObject.GetComponent<ParticleSystem>().main.duration);
        }

        Destroy(gameObject);
    }
}
