namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public static class StringUtils
    {
        public static int GetStableHashCode(this string str)
        {
            unchecked
            {
                int hash = 5381;
                foreach (char c in str)
                    hash = (hash * 33) ^ c;
                return hash;
            }
        }
    }
}
