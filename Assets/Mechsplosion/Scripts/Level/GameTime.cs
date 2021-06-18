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
        public TMP_Text livesText;
        public GameObject levelOne;
        public GameObject levelTwo;
        public int lives;
        public GameObject pauseMenu;


        // Start is called before the first frame update
        void Start()
        {
            lives = 10;
            pauseMenu.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (fiveMin == true)
            {
                fiveMinuteTimer -= 1 * Time.deltaTime;
                timeText.text = fiveMinuteTimer.ToString("F0");
            }
            if (twoMin == true)
            {
                twoMinuteTimer -= 1 * Time.deltaTime;
                timeText.text = twoMinuteTimer.ToString("F0");
            }
            if(noLimit == true)
            {
                timeText.gameObject.SetActive(false);
            }
            else
            {
                timeText.gameObject.SetActive(true);
            }
            livesText.text = "Lives: " + lives.ToString();
            if(lives == 0)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
