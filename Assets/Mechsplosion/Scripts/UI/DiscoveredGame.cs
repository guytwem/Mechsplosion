using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Mechsplosion.Networking;

namespace Mechsplosion.UI
{
    [RequireComponent(typeof(Button))]
    public class DiscoveredGame : MonoBehaviour
    {
        public string GameName => response.gameName;

        [SerializeField] private TextMeshProUGUI ipDisplay;

        private MechsplosionNetworkManager networkManager;
        private DiscoveryResponse response;

        public void Setup(DiscoveryResponse _response, MechsplosionNetworkManager _manager)
        {
            UpdateResponse(_response);
            networkManager = _manager;

            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(JoinGame);
        }

        public void UpdateResponse(DiscoveryResponse _response)
        {
            response = _response;
            ipDisplay.text = $"<b>{response.gameName}</b>\n{response.EndPoint.Address}";
        }

        private void JoinGame()
        {
            // When we click the button, connect to the server displayed on the button
            networkManager.networkAddress = response.EndPoint.Address.ToString();
            networkManager.StartClient();
        }
    }
}