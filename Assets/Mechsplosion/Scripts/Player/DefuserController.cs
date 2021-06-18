using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;
using Mirror.Experimental;
using Mechsplosion.MatchSettings;

/// <summary>
/// This script is used by players playing as 'defusers'
/// </summary>
[RequireComponent(typeof(NetworkIdentity))]
public class DefuserController : NetworkBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    /// <summary>
    /// Slightly misleading name - this is the strength of their forwards push
    /// </summary>
    [SerializeField]
    private float jumpForce = 10.0f;
    private Rigidbody defuserRigidbody;
    private Vector3 direction;
    private GameTime settings;

    [SyncVar]
    public Vector3 Position = Vector3.zero;
    [SyncVar]
    public Quaternion Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        defuserRigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    [Client]
    void Update()
    {

        if (!hasAuthority)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            Punch();

    }

    [Client]
    private void FixedUpdate()
    {

        if (!hasAuthority)
            return;

        Move();
    }

    /// <summary>
    /// Moves the defuser in the direction of the wasd or arrow keys
    /// </summary>
    private void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = Vector3.ClampMagnitude(direction, 1.0f);
        defuserRigidbody.MovePosition(defuserRigidbody.position + direction * moveSpeed * Time.deltaTime);
        if(direction.magnitude > 0.1f)
            defuserRigidbody.MoveRotation(Quaternion.LookRotation(direction, Vector3.up));

        //AssignValues();
    }

    /*
    private void AssignValues()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        UpdateValues();
    }

    [ClientRpc]
    private void UpdateValues()
    {
        transform.position = Position;
        transform.rotation = Rotation;
    }

    */
    /// <summary>
    /// Pushes the defuser forwards - this is how they damage the energy shield
    /// </summary>
    private void Punch()
    {
        defuserRigidbody.AddForce(direction * jumpForce, ForceMode.Impulse);
    }

    private void Death()
    {
        gameObject.transform.position = new Vector3(10, 4, 0);
        CmdLives();
    }

    [Command]
    private void CmdLives()
    {
        settings.lives--;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            Death();
        }
    }
}
