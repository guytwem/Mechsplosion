using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

/// <summary>
/// An object that a MechController can interact with
/// </summary>
public class LevelInteractable : NetworkBehaviour
{
    protected float moveSpeed = 1.0f;

    /// <summary>
    /// The level controller calls this function to use this interactable
    /// </summary>
    /// <param name="_location">The target location for the action</param>
    public void UseInteractable(Vector3 _location)
    {
        StopCoroutine(nameof(Interaction));
        StartCoroutine(nameof(Interaction), _location);
    }

    /// <summary>
    /// Default action for an interactable - it moves towards the specified location
    /// </summary>
    /// <param name="_location">The location it moves to</param>
    protected virtual IEnumerator Interaction(Vector3 _location)
    {
        float lerpVal = 0;
        Vector3 oldPos = transform.position;
        float distance = (oldPos - _location).magnitude;
        while ((transform.position - _location).magnitude / distance > 0.01f)
        {
            transform.position = Vector3.Lerp(oldPos, _location, lerpVal);
            lerpVal += moveSpeed * Time.deltaTime;
            yield return null;
        }
        transform.position = _location;
    }
}
