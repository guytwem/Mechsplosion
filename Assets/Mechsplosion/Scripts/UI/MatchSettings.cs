using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Mechsplosion.MatchSettings
{
    public class MatchSettings : MonoBehaviour
    {
        [SerializeField]
        private GameTime gameTime;
        [SerializeField]
        private Bomb bomb;
        [SerializeField]
        private Shield core;
        [SerializeField]
        private Shield core2;


        public void FavourDefusers()
        {
            bomb.strength = 10;
            bomb.radius = 3;
            core.health = 75;
            core2.health = 75;
        }

        public void FavourMech()
        {
            bomb.strength = 15;
            bomb.radius = 5;
            core.health = 100;
            core2.health = 100;
        }

        public void Normal()
        {
            bomb.strength = 10;
            bomb.radius = 3;
            core.health = 100;
            core2.health = 100;
        }

        public void NoTimeLimit()
        {
            gameTime.noLimit = true;
            gameTime.twoMin = false;
            gameTime.fiveMin = false;
        }

        public void TwoMinuteLimit()
        {
            gameTime.noLimit = false;
            gameTime.twoMin = true;
            gameTime.fiveMin = false;
        }

        public void FiveMinuteLimit()
        {
            gameTime.noLimit = false;
            gameTime.twoMin = false;
            gameTime.fiveMin = true;
        }
        
        public void LevelOneSelect()
        {
            gameTime.levelOne.SetActive(true);
            gameTime.levelTwo.SetActive(false);
        }

        public void LevelTwoSelect()
        {
            gameTime.levelOne.SetActive(false);
            gameTime.levelTwo.SetActive(true);
        }
    }
}
