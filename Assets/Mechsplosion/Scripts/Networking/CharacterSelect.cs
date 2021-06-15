using UnityEngine;
using Mirror;
using Mechsplosion.Networking;

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
        GameObject characterInstance = Instantiate(MechsplosionNetworkManager.Instance.IsHost ? characterList[0] : characterList[1], transform.position, Quaternion.identity);
        
        NetworkServer.Spawn(characterInstance, sender);
        characterInstance.GetComponent<NetworkIdentity>().AssignClientAuthority(sender);
        //characterInstance.GetComponent<PlayerController>().Setup();
        //characterInstance.GetComponent<PlayerController>().Setup();
    }
}