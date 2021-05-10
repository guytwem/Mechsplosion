using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefuserController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float jumpForce = 10.0f;
    private Rigidbody defuserRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        defuserRigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void FixedUpdate()
    {
        defuserRigidbody.MovePosition(defuserRigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        defuserRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
