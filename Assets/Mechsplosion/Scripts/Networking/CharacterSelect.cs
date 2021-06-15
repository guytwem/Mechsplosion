using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

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
        GameObject characterInstance = Instantiate(isClientOnly ? characterList[1] : characterList[0], transform.position, Quaternion.identity);
        
        NetworkServer.Spawn(characterInstance, sender);
        characterInstance.GetComponent<NetworkIdentity>().AssignClientAuthority(sender);
        //characterInstance.GetComponent<PlayerController>().Setup();
        //characterInstance.GetComponent<PlayerController>().Setup();
    }
}
