using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is attached to the shield surrounding the crystal, which loses health on impact with anything
/// </summary>
public class Shield : MonoBehaviour
{
    public float health = 10.0f;
    private float originalHealth;
    [SerializeField] private MeshRenderer crystal;
    private Color originalColor;

    private void Start()
    {
        originalColor = crystal.material.color;
        originalHealth = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        health -= collision.rigidbody.velocity.magnitude;
        crystal.material.color = Color.Lerp(Color.red, originalColor, health / originalHealth);
        if (health < 0)
            Destroy(gameObject);
    }
}
