using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deimaginator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().Atack(otherObject);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    GetComponent<Animator>().SetBool("IsAttacking", false);
    //}
}
