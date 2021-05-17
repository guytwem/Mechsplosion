using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private LevelInteractable currentInteractable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
