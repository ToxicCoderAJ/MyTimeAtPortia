using System;
using System.Reflection;
using Harmony12;
using UnityEngine;
using UnityModManagerNet;

namespace Experience_Rewards_Difficulty
{
    public static class Main
    {

        public static void Dbgl(string str = "", bool pref = true)
        {
            bool flag = Main.isDebug;
            if (flag)
            {
                Debug.Log((pref ? (typeof(Main).Namespace + " ") : "") + str);
            }
        }
        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            Main.horizSliderBg = new Texture2D(1, 1);
            Main.horizSliderBg.SetPixel(0, 0, new Color(0.33f, 0.43f, 0.48f));
            Main.horizSliderBg.Apply();
            modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
            modEntry.OnGUI = new Action<UnityModManager.ModEntry>(Main.OnGUI);
            modEntry.OnSaveGUI = new Action<UnityModManager.ModEntry>(Main.OnSaveGUI);
            Main.settings = UnityModManager.ModSettings.Load<Settings>(modEntry);
            HarmonyInstance harmonyInstance = HarmonyInstance.Create(modEntry.Info.Id);
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            return true;

        }
        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Main.Enabled = value;
            return true;
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Main.settings == null)
            {
                return;
            }
            GUI.skin.horizontalSlider.normal.background = Main.horizSliderBg;
            GUI.skin.label.richText = true;
            GUILayout.Label(string.Format("Experience Multiplied by <b>{0:F1}</b>", Main.settings.ExpMultiplier), new GUILayoutOption[0]);
            Main.settings.ExpMultiplier = GUILayout.HorizontalSlider(Main.settings.ExpMultiplier, 1f, 1000f, new GUILayoutOption[0]);
            Main.settings.ExpMultiplier = (float)Math.Round((double)Main.settings.ExpMultiplier, 1);
            GUILayout.Space(10f);
            GUILayout.Label(string.Format("Money Multiplied by <b>{0:F1}</b>", Main.settings.MoneyMultiplier), new GUILayoutOption[0]);
            Main.settings.MoneyMultiplier = GUILayout.HorizontalSlider(Main.settings.MoneyMultiplier, 1f, 5f, new GUILayoutOption[0]);
            Main.settings.MoneyMultiplier = (float)Math.Round((double)Main.settings.MoneyMultiplier, 1);
            GUILayout.Space(10f);
            GUILayout.Label(string.Format("MiniGame Reward Multiplied by <b>{0:F1}</b>", Main.settings.MiniGameRewardMultiplier), new GUILayoutOption[0]);
            Main.settings.MiniGameRewardMultiplier = GUILayout.HorizontalSlider(Main.settings.MiniGameRewardMultiplier, 1f, 5f, new GUILayoutOption[0]);
            Main.settings.MiniGameRewardMultiplier = (float)Math.Round((double)Main.settings.MiniGameRewardMultiplier, 1);
            GUILayout.Space(10f);
/*            GUILayout.Label(string.Format("Attack Damage Multiplied by !Testing!<b>{0:F1}</b>", Main.settings.AttackMultiplier), new GUILayoutOption[0]);
            Main.settings.AttackMultiplier = GUILayout.HorizontalSlider(Main.settings.AttackMultiplier, 1f, 100f, new GUILayoutOption[0]);
            Main.settings.AttackMultiplier = (float)Math.Round((double)Main.settings.AttackMultiplier, 1);
            GUILayout.Space(10f);*/
            GUILayout.Label(string.Format("Add Money by <b>${0:F1}</b>", Main.settings.PressButton), new GUILayoutOption[0]);
            Main.settings.PressButton = GUILayout.HorizontalSlider(Main.settings.PressButton, 1f, 1000000f, new GUILayoutOption[0]);
            Main.settings.PressButton = (float)Math.Round((double)Main.settings.PressButton, 1);
            GUILayout.Space(10f);
            GUILayout.Label(string.Format("Add RelationshipMultiplier by <b>{0:F1}</b>", Main.settings.RelatioshipMuiltiplier), new GUILayoutOption[0]);
            Main.settings.RelatioshipMuiltiplier = GUILayout.HorizontalSlider(Main.settings.RelatioshipMuiltiplier, 1f, 10f, new GUILayoutOption[0]);
            Main.settings.RelatioshipMuiltiplier = (float)Math.Round((double)Main.settings.RelatioshipMuiltiplier, 1);
            GUILayout.Space(10f);

        }

        private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Main.settings.Save(modEntry);
        }

        private static readonly bool isDebug = true;
        public static Settings settings;
        public static bool Enabled;
        private static Texture2D horizSliderBg;
    }
}
