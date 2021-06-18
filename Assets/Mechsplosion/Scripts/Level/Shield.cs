using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is attached to the shield surrounding the crystal, which loses health on impact with anything
/// </summary>
public class Shield : MonoBehaviour
{
    public float health = 100.0f;

    private void OnCollisionEnter(Collision collision)
    {
        health -= collision.rigidbody.velocity.magnitude;
        Debug.Log(health);
        if (health < 0)
            Destroy(gameObject);
    }
}
