using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private float health = 100.0f;

    private void OnCollisionEnter(Collision collision)
    {
        health -= collision.rigidbody.velocity.magnitude;
        Debug.Log(health);
        if (health < 0)
            Destroy(gameObject);
    }
}
