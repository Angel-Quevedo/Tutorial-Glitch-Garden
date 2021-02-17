using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        var otherObject = collision.gameObject;

        if (otherObject.GetComponent<Enemy>())
        {
            // do simething
        }
    }
}
