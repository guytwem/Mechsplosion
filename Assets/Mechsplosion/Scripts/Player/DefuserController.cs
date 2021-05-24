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
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        defuserRigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Punch();
    }

    private void FixedUpdate()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = Vector3.ClampMagnitude(direction, 1.0f);
        defuserRigidbody.MovePosition(defuserRigidbody.position + direction * moveSpeed * Time.deltaTime);
        if(direction.magnitude > 0.1f)
            defuserRigidbody.MoveRotation(Quaternion.LookRotation(direction, Vector3.up));
    }

    private void Punch()
    {
        defuserRigidbody.AddForce(direction * jumpForce, ForceMode.Impulse);
    }
}
