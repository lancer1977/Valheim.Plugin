using System;
using HarmonyLib;
using PolyhydraGames.Valheim.Plugin.Commands.Shake;
using PolyhydraGames.Valheim.Plugin.Extensions;
using Logger = Jotunn.Logger;

namespace PolyhydraGames.Valheim.Plugin.Commands.Whisper;

/// <summary>
/// Shakes the player around
/// </summary>
[HarmonyPatch(typeof(Game))]
public static class WhisperRpc
{

    [HarmonyPostfix]
    [HarmonyPatch("Start")]
    private static void Register()
    {
        Logger.LogInfo("Registered " + nameof(ShakeRpc));
        ZRoutedRpc.instance.Register<string, string>(Metadata.RCPCall, Whisper);
    }

    private static void Whisper(long sender, string name, string message)
    {
        Logger.LogInfo($"Received {Metadata.RCPCall}, name: {name} message: {message}");

        if (Player.m_localPlayer == null || GameCamera.instance == null)
        {
            return;
        }

        try
        {
            Chat.instance.AddString(name,message, Talker.Type.Normal);
            UIHelpers.ShowPopup(MessageHud.MessageType.TopLeft, $"{name}: {message}");
            Logger.LogInfo($"Whisper shake triggered with amount ");

        }
        catch (Exception ex)
        {
            Logger.LogInfo($"Screen shake failed. " + ex.Message);
        }

    }




}