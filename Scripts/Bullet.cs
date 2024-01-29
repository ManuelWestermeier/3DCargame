using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    private void OnCollisionEnter(Collision other) {
        rb.velocity = rb.velocity * 1.2f;
        if (other.gameObject.tag == "Gegner")
        {
            other.transform.gameObject.tag = "Untagged";
        }
    }
}
