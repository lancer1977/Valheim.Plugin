namespace PolyhydraGames.RCon.Test
{
    public static class PlayerIds
    {
        public const string DreadId = "76561197962914477";
        public const string LockId = "76561198080456333";
        public const string LanceId = "76561198150290231";
        public const string GingerId = "76561198006885330";
        public const string AlecktoId = "76561198095936057";
        public const string PoohId = "76561199439067919";
        public static readonly Dictionary<string, string> DefaultPlayers = new()
        {
            { "76561197962914477", "DreadId" },
            { "76561198080456333", "LockId" },
            { "76561198150290231", "LanceId" },
            { "76561198006885330", "GingerId" },
            { "76561198095936057", "AlecktoId" },
            { "76561199439067919", "PoohId" }
        };
    }
}