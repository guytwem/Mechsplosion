using UnityEngine;
using Mirror;
using Mechsplosion.Networking;

/// <summary>
/// This script makes it so that the host plays as the mech, and the clients play as defusers
/// </summary>
public class CharacterSelect : NetworkBehaviour
{
    [SerializeField] private GameObject[] characterList = default;

    public override void OnStartClient()
    {
        CmdSelect();
    }

    [Command(requiresAuthority = false)]
    public void CmdSelect(NetworkConnectionToClient sender = null)
    {
        GameObject characterInstance = Instantiate(LevelController.Instance == null ? characterList[0] : characterList[1], transform.position, Quaternion.identity); ; ;
        
        NetworkServer.Spawn(characterInstance, sender);
        characterInstance.GetComponent<NetworkIdentity>().AssignClientAuthority(sender);
        //characterInstance.GetComponent<PlayerController>().Setup();
        //characterInstance.GetComponent<PlayerController>().Setup();
    }
}
