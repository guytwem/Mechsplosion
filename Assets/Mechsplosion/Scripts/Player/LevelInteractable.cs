using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelInteractable : MonoBehaviour
{
    protected float moveSpeed = 1.0f;

    public void UseInteractable(Vector3 _location)
    {
        StartCoroutine(nameof(Interaction), _location);
    }

    protected virtual IEnumerator Interaction(Vector3 _location)
    {
        float lerpVal = 0;
        while ((transform.position - _location).magnitude < 0.1)
        {
            transform.position = Vector3.Lerp(transform.position, _location, lerpVal);
            lerpVal += moveSpeed * Time.deltaTime;
            yield return null;
        }
        transform.position = _location;
    }
}
