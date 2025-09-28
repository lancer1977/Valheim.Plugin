using System;
using System.Collections.Generic;
using System.Linq;
using PolyhydraGames.Valheim.Plugin.Extensions;
using Splatform;
using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands
{
    internal class Impersonate : RconCommand
    {
        private static readonly Dictionary<string, UserInfo> ImpersonatedUsers = new Dictionary<string, UserInfo>();
        private static ulong NextId = 1;
        public     UserInfo CreateUser(string name) => new UserInfo
        {
            Name = name,
            UserId = new PlatformUserID("Bot", NextId++, false),
        };
        public override string Command => "impersonate";

        public override string Description => "Sends a message to the chat as a shout. Usage: impersonate <name> <message>";
        private UserInfo GetUserInfo(string name)
        {
            var existing = ImpersonatedUsers.ContainsKey(name);
            if (existing) return ImpersonatedUsers[name];
            var newUser = CreateUser(name); 
            return newUser;
        }
        protected override string OnHandle(CommandArgs args)
        {
            if (args.Arguments.Count < 2)
                return "Usage: impersonate <name> <message>";
            var name = "";
            var message = ""; 
            try
            {
                name = args.GetString(0); 
                message = args.GetRemainingString(1); // Everything else is message  
                if (!ZoneSystem.instance.GetLocationIcon(Game.instance.m_StartLocation, out var location))
                    location = new Vector3(0, 30, 0); 
                ZRoutedRpc.instance.InvokeRoutedRPC(ZRoutedRpc.Everybody,
                    "Whisper",
                    location,
                    (int)Talker.Type.Shout,
                    GetUserInfo(name),
                    message);

                return $"Impersonated: {name} - {message}";
            }
            catch (Exception ex)
            {
                return ex.Message + $" FAILED  !!! Impersonated: {name} - {message}";
            }

        }
    }
}