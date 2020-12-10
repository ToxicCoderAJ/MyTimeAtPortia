using System;
using Harmony12;
using Pathea;
using UnityEngine;
using Pathea.MiniGameNs;
using Pathea.ItemSystem;
using Pathea.FavorSystemNs;
using System.Collections.Generic;

namespace Experience_Rewards_Difficulty.patch
{
	[HarmonyPatch(typeof(Player), "AddExp", 0)]
	internal static class PlayerAddExpPatch
	{
		private static void Prefix(ref int exp)
		{
			if (!Main.Enabled)
			{
				return;
			}
			exp = Mathf.RoundToInt((float)exp * Main.settings.ExpMultiplier);
		}

	}

	/*    [HarmonyPatch(typeof(AttrData), "Attack", 0)]
		internal static class PlayerAttackDamagePatch
		{
			private static void Prefix(ref int attack)
			{
				if (!Main.Enabled)
				{
					return;
				}
				attack = Mathf.RoundToInt((float)attack * Main.settings.AttackMultiplier);
			}
		}*/

	[HarmonyPatch(typeof(ItemBag), "ChangeMoney", 0)]
	internal static class PlayerGainMoneyPatch
	{
		private static void Prefix(ref int baseValue, bool showTip = true, int extra = 0)
		{
			if (!Main.Enabled)
			{
				return;
			}

			baseValue = Mathf.RoundToInt((float)baseValue * Main.settings.PressButton);


		}

	}

	[HarmonyPatch(typeof(FavorObject), "GainFavorValue", 0)]
	internal static class RelationshipPatch
    {
		private static void Prefix(ref int gainFavorValue)
        {
			if (!Main.Enabled)
            {
				return;
            }

			gainFavorValue = Mathf.RoundToInt((float)gainFavorValue * Main.settings.RelatioshipMuiltiplier);
		}
    }

    [HarmonyPatch(typeof(Player), "GainItems", 0)]
    internal static class PlayerGainItemsPatch
    {
        private static void Prefix(ref int money)
        {
            if (!Main.Enabled)
            {
                return;
            }
            money = Mathf.RoundToInt((float)money * Main.settings.MoneyMultiplier);

        }

    }

    [HarmonyPatch(typeof(MiniGameRewardMgr), "GetBalloonReward", 0)]
	internal static class MiniGameRewardMgrGetBalloonRewardPatch
	{
		private static void Postfix(ref List<ItemObject> __result)
		{
			if (!Main.Enabled)
			{
				return;
			}
			foreach (ItemObject itemObject in __result)
			{
				int number = Mathf.RoundToInt((float)itemObject.Number * Main.settings.MiniGameRewardMultiplier) - itemObject.Number;
				itemObject.ChangeNumber(number);
			}
		}
	}

	[HarmonyPatch(typeof(MiniGameRewardMgr), "GetDartReward", 0)]
	internal static class MiniGameRewardMgrGetDartRewardPatch
	{
		private static void Postfix(ref List<ItemObject> __result)
		{
			if (!Main.Enabled)
			{
				return;
			}
			foreach (ItemObject itemObject in __result)
			{
				int number = Mathf.RoundToInt((float)itemObject.Number * Main.settings.MiniGameRewardMultiplier) - itemObject.Number;
				itemObject.ChangeNumber(number);
			}
		}
	}

	[HarmonyPatch(typeof(MiniGameRewardMgr), "GetSlotMachineReward", new Type[]
	{
			typeof(string),
			typeof(int)
	})]
	internal static class MiniGameRewardMgrGetSlotMachineRewardPatch
	{
		private static void Postfix(ref List<ItemObject> __result)
		{
			if (!Main.Enabled)
			{
				return;
			}
			foreach (ItemObject itemObject in __result)
			{
				int number = Mathf.RoundToInt((float)itemObject.Number * Main.settings.MiniGameRewardMultiplier) - itemObject.Number;
				itemObject.ChangeNumber(number);
			}
		}
	}
}
