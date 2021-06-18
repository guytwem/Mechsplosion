using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.Translate(Vector3.up * 50.0f);
    }
}
