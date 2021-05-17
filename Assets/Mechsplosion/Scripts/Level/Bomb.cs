using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float fuse = 5.0f;
    [SerializeField] private float strength = 10.0f;
    [SerializeField] private float radius = 2.0f;
    [SerializeField] private float upwardsModifier = 2.0f;

    private List<Rigidbody> targets;

    private void Awake()
    {
        targets = new List<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(nameof(CountDown));
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if(target != null)
        {
            targets.Add(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (target != null)
        {
            targets.Remove(target);
        }
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(fuse);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        foreach(Rigidbody target in targets)
        {
            if(target != null)
                target.AddExplosionForce(strength, transform.position, radius, upwardsModifier, ForceMode.VelocityChange);
        }
    }
}
