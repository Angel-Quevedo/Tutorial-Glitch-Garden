using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.GetComponent<Gravestone>())
                Jump();
            else
                GetComponent<Enemy>().Atack(otherObject);
        }
    }

    private void Jump()
    {
        GetComponent<Animator>().SetBool("JumpDone", true);
        GetComponent<Animator>().SetTrigger("JumpTrigger");
    }
}
