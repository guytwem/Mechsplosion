using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Turret")
                {
                    Debug.Log("Hit Turret");
                    gameObject.transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X"), 0));
                }
                else
                {
                    Debug.Log("Nothing Hit");
                }
            }
        }
    }
}
