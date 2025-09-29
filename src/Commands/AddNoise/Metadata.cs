using UnityEngine;

namespace PolyhydraGames.Valheim.Plugin.Commands.AddNoise
{
    public static class Metadata
    {
        public const string TestString = "addnoise 76561197962914477 https://cdn.polyhydragames.com/audio/no.mp3 10 10 1";
        public const string RCPCall = "AddNoise";
        public const string Command = "addnoise";
        public const string Description = "Plays a noise in the vicinity of the player.";
        public const string Usage = "Usage: addnoise <player> <noiseName> <position>";
        public const int MinimumParameters = 2;

    }
}
