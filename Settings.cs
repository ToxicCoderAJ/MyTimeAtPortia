using System;
using UnityModManagerNet;

namespace Experience_Rewards_Difficulty
{
	public class Settings : UnityModManager.ModSettings
	{
		public float ExpMultiplier
        {
            get
            {
                return this.expMultiplier;
            }
            set
            {
                this.expMultiplier = value;
            }
        }

        public float MoneyMultiplier
        {
            get
            {
                return this.moneyMultiplier;
            }
            set
            {
                this.moneyMultiplier = value;
            }
        }

        public float MiniGameRewardMultiplier
        {
            get 
            { 
                return this.miniGameRewardMultiplier;
            }
            set 
            { 
                this.miniGameRewardMultiplier = value;
            }
        }

/*        public float AttackMultiplier
        {
            get { return this.attackMultiplier; }
            set { this.attackMultiplier = value; }
        }*/

        public float PressButton
        {
            get 
            {
                return this.pressButton; 
            }
            set 
            {
                this.pressButton = value; 
            }
        }

        public float RelatioshipMuiltiplier
        {
            get
            {
                return this.relatioshipMuiltiplier;
            }

            set
            {
                this.relatioshipMuiltiplier = value;
            }
        }
        public override void Save(UnityModManager.ModEntry modEntry)
        {
            UnityModManager.ModSettings.Save<Settings>(this, modEntry);
        }

        private float relatioshipMuiltiplier = 1.5f;
        private float pressButton = 1.5f;
        private float moneyMultiplier = 1.5f;
        private float expMultiplier = 1.5f;
        private float miniGameRewardMultiplier = 1f;
        //private float attackMultiplier = 1f;

    }
}
