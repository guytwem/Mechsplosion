using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Mechsplosion.MatchSettings
{
    public class GameTime : MonoBehaviour
    {
        public float fiveMinuteTimer = 300;
        public float twoMinuteTimer = 120;
        public bool fiveMin = false;
        public bool twoMin = false;
        public bool noLimit = true;
        public TMP_Text timeText;
        public GameObject levelOne;
        public GameObject levelTwo;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (fiveMin == true)
            {
                fiveMinuteTimer -= 1 * Time.deltaTime;
                timeText.text = fiveMinuteTimer.ToString();
            }
            if (twoMin == true)
            {
                twoMinuteTimer -= 1 * Time.deltaTime;
                timeText.text = twoMinuteTimer.ToString();
            }
            if(noLimit == true)
            {
                timeText.gameObject.SetActive(false);
            }
        }
    }
}
