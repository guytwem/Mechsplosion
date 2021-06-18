using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/// <summary>
/// This script is used by the player playing as the 'mech' 
/// </summary>
public class LevelController : NetworkBehaviour
{
    /// <summary>
    /// The object being interacted with
    /// </summary>
    private LevelInteractable currentInteractable;

    public static LevelController Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit mouseClick = GetMouseClick();
            if (mouseClick.point != Vector3.zero)
            {
                currentInteractable = mouseClick.collider.transform.gameObject.GetComponent<LevelInteractable>();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(currentInteractable != null)
            {
                currentInteractable.UseInteractable(GetMouseClick().point + Vector3.up);
            }
        }
    }

    /// <summary>
    /// Fires a raycast from the mouse, and returns the first object hit
    /// </summary>
    private RaycastHit GetMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Interactable"))
                return hit;
        }
        return hits.Length > 0 ? hits[0] : default;
    }
}
