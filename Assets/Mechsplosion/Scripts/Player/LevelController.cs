using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LevelController : NetworkBehaviour
{
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
