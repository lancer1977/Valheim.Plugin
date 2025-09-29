using System;
using HarmonyLib;
using PolyhydraGames.Valheim.Plugin.Extensions;
using Logger = Jotunn.Logger;

namespace PolyhydraGames.Valheim.Plugin.Commands.Shake;

/// <summary>
/// Shakes the player around
/// </summary>
[HarmonyPatch(typeof(Game))]
public static class ShakeRpc
{

    [HarmonyPostfix]
    [HarmonyPatch("Start")]
    private static void Register()
    {
        Logger.LogInfo("Registered " + nameof(ShakeRpc));
        ZRoutedRpc.instance.Register<string>(Metadata.RCPCall, Shake);
    }

    private static void Shake(long sender, string shake)
    {
        Logger.LogInfo($"Received Screen Shake, amount: {shake}");
     
        if (Player.m_localPlayer == null || GameCamera.instance == null)
        {
            return;
        }

        try
        {
            var range = 10f; //The radius of the shake
            var shakeAmount = float.Parse(shake);
            var point = Player.m_localPlayer.GetPosition();
            GameCamera.instance.AddShake(point, range, shakeAmount, false);

            Logger.LogInfo($"Screen shake triggered with amount {shakeAmount}");
        }
        catch (Exception ex)
        {

            Logger.LogInfo($"Screen shake failed. " + ex.Message);
        }
  

    }




}