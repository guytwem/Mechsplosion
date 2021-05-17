using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : LevelInteractable
{
    [SerializeField] private float turnDuration = 1.0f;
    [SerializeField] private GameObject projectile;

    protected override IEnumerator Interaction(Vector3 _location)
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan((_location.x - transform.position.x) / (_location.z - transform.position.z));
        angle -= _location.z < transform.position.z ? 180.0f : 0.0f;
        Quaternion oldRotation = transform.rotation;
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.up);
        float timer = 0.0f;

        while (timer < turnDuration)
        {
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
