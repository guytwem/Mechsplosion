using Mechsplosion.MatchSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

/// <summary>
/// The barrier that makes defusers respawn if they fall too far
/// </summary>
public class KillPlane : NetworkBehaviour
{
    [SerializeField] private GameTime settings;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.Translate(Vector3.up * 50.0f);
        CmdLives();
    }

    [Command(requiresAuthority = false)]
    private void CmdLives()
    {
        settings.lives--;

    }
}
