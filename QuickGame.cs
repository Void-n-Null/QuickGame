using MelonLoader;
using BTD_Mod_Helper;
using QuickGame;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using UnityEngine.UI;
using BTD_Mod_Helper.Api.ModOptions;
using System;

[assembly: MelonInfo(typeof(QuickGame.QuickGame), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace QuickGame;

public class QuickGame : BloonsTD6Mod
{
    public bool GameStart = true;
    public enum diff { Easy, Medium, Hard }
    public enum mode { Sandbox, Standard, MagicOnly, Impoppable, Chimps, HalfCash }
    public ModSettingEnum<diff> Difficulty = new ModSettingEnum<diff>(diff.Easy);
    public ModSettingEnum<mode> Mode = new ModSettingEnum<mode>(mode.Sandbox);
    public override void OnApplicationStart()
    {

    }

    public override void OnMainMenu()
    {
        if (GameStart)
        {
            var mode = Difficulty.GetValue().ToString();
            if (mode == "Chimps")
            {
                mode = "Clicks";
            }
            InGameData.Editable.selectedMode = mode;
            InGameData.Editable.selectedMap = "Tutorial";
            InGameData.Editable.selectedDifficulty = Difficulty.GetValue().ToString();
            UI.instance.LoadGame();
            GameStart = false;
        }
    }

    public override void OnTitleScreen()
    {
        var button = GameObject.Find("Canvas/ScreenBoxer/TitleScreen/Start");
        button.GetComponent<Button>().onClick.Invoke();
    }
}